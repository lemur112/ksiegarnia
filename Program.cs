using Newtonsoft.Json;
using System.Reflection.Metadata;
using System.Transactions;

namespace ksiegarnia
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            Console.WriteLine("Witaj w ksiegarni!");
            Console.WriteLine("Wybierz opcje:");
            Console.WriteLine("1) Wyświetl wszystkie książki");
            Console.WriteLine("2) Wyszukaj książkę po tytule");
            Console.WriteLine("3) Dodaj nową książkę");
            Console.WriteLine("4) Usuń książkę");
            Console.WriteLine("5) Wyjdź");
            
            bool czyPoprawnaOpcja = int.TryParse(Console.ReadLine(), out int opcja);
            if (czyPoprawnaOpcja)
            {
                switch (opcja)
                {
                    case 1:
                        WyswietlWszystkieKsiazki();
                        break;
                    case 2:
                        WyszukajKsiazkePoTytule();
                        break;
                    case 3:
                        DodajKsiazke();
                        break;
                    case 4:
                        UsunKsiazke();
                        break;
                    case 5:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Niepoprawny wybór");
                        return;

                }
            }
            else
            {   
                Console.Clear();
                Console.WriteLine("Niepoprawny wybór! \n Naciśnij Enter aby wrócic do menu...");
                Console.ReadLine();
                Main(null);
                
            }
            
            

            
        }
        public static void WyswietlWszystkieKsiazki()
        {
            Console.Clear();
            string json = File.ReadAllText("ksiazki.json");
            List<JsonModel> ksiazki = JsonConvert.DeserializeObject<List<JsonModel>>(json);

            Console.WriteLine("Wszystkie książki: ");
            foreach (var ksiazka in ksiazki)
            {
                Console.WriteLine(
                    $"{ksiazka.ID}.\n" +
                    $"{ksiazka.tytul} - {ksiazka.Autor} \n" +
                    $"Rok Wydania: {ksiazka.RokWydania}, Gatunek: {ksiazka.Gatunek} \n");
            }
            Console.WriteLine("Naciśnij Enter aby wrócić do menu...");
            Console.ReadLine();
            Main(null);
        }
        public static void WyszukajKsiazkePoTytule()
        {
            Console.Clear();
            string json = File.ReadAllText("ksiazki.json");
            List<JsonModel> ksiazki = JsonConvert.DeserializeObject<List<JsonModel>>(json);

            Console.WriteLine("Podaj tytuł książki: ");
            string szukanyTytul = Console.ReadLine();

            if(string.IsNullOrEmpty(szukanyTytul))
            {
                Console.WriteLine("Nie podano tytułu książki");
                Console.WriteLine("Naciśnij Enter aby wrócić do menu...");
                Console.ReadLine();
                Main(null);
            }

            bool czyZnaleziono = false;
            foreach (var ksiazka in ksiazki)
            {
                if (ksiazka.tytul.Contains(szukanyTytul))
                {
                    Console.Clear();
                    Console.WriteLine("Znaleziono książkę: \n");
                    czyZnaleziono = true;
                    Console.WriteLine(
                    $"{ksiazka.ID}.\n" +
                    $"{ksiazka.tytul} - {ksiazka.Autor} \n" +
                    $"Rok Wydania: {ksiazka.RokWydania}, Gatunek: {ksiazka.Gatunek} \n");
                }
                 
            }

            if(!czyZnaleziono)
            {
                Console.WriteLine("Nie znaleziono ksiązki o podanym tytule");
            }
            Console.WriteLine("Naciśnij Enter aby wrócić do menu...");
            Console.ReadLine();
            Main(null);
        }
        public static void DodajKsiazke()
        {
            Console.Clear();
            string json = File.ReadAllText("ksiazki.json");
            List<JsonModel> ksiazki = JsonConvert.DeserializeObject<List<JsonModel>>(json);

            Console.WriteLine("Podaj tytuł książki: ");
            string tytul = Console.ReadLine();

            Console.WriteLine("\n Podaj autora książki: ");
            string autor = Console.ReadLine();

            Console.WriteLine("\n Podaj rok wydania książki: ");
            string rokWydania = Console.ReadLine();

            Console.WriteLine("\n Podaj gatunek książki: ");
            string gatunek = Console.ReadLine();

            ksiazki.Add(new JsonModel
            {
                ID = (ksiazki.Count + 1).ToString(),
                tytul = tytul,
                Autor = autor,
                RokWydania = rokWydania,
                Gatunek = gatunek
            });
            
            json = JsonConvert.SerializeObject(ksiazki);
            File.WriteAllText("ksiazki.json", json);

            Console.WriteLine($"Dodano nową książke i nadano jej id: {ksiazki.Count} ");
            Console.WriteLine("Naciśnij Enter aby wrócić do menu...");
            Console.ReadLine();
            Main(null);


        }

        public static void UsunKsiazke()
        {
            Console.Clear();
            string json = File.ReadAllText("ksiazki.json");
            List<JsonModel> ksiazki = JsonConvert.DeserializeObject<List<JsonModel>>(json);

            foreach (var ksiazka in ksiazki)
            {
                Console.WriteLine(
                    $"{ksiazka.ID}.\n" +
                    $"{ksiazka.tytul} - {ksiazka.Autor} \n" +
                    $"Rok Wydania: {ksiazka.RokWydania}, Gatunek: {ksiazka.Gatunek} \n");
            }

            Console.WriteLine("Podaj ID książki do usunięcia: ");
            bool czyPoprawneId = int.TryParse(Console.ReadLine(), out int id);
            if (czyPoprawneId)
            {
                JsonModel ksiazkaDoUsuniecia = ksiazki.FirstOrDefault(x => x.ID == id.ToString());
                if (ksiazkaDoUsuniecia != null)
                {
                    ksiazki.Remove(ksiazkaDoUsuniecia);
                    json = JsonConvert.SerializeObject(ksiazki);
                    File.WriteAllText("ksiazki.json", json);
                    Console.WriteLine("Usunięto książkę");
                }
                else
                {
                    Console.WriteLine("Nie znaleziono książki o podanym ID");
                }
            }
            else
            {
                Console.WriteLine("Niepoprawne ID");
            }

        }
    }
}