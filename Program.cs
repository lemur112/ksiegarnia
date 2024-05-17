using Newtonsoft.Json;
using System.Reflection.Metadata;
using System.Transactions;
// PLIK JSON ZNAJDUJĄ SIE W FOLDERZE BIN/DEBUG
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

            if (int.TryParse(Console.ReadLine(), out int opcja))
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
            Console.WriteLine("Wszystkie książki: ");
            string json = File.ReadAllText("ksiazki.json");
            List<Ksiazka> ksiazki = JsonConvert.DeserializeObject<List<Ksiazka>>(json);
            List<KsiazkaElektroniczna> ksiazkiElektroniczne = JsonConvert.DeserializeObject<List<KsiazkaElektroniczna>>(json);
            if (ksiazki != null)
            {
                foreach (var ksiazka in ksiazkiElektroniczne)
                {
                    Console.WriteLine(
                        $"{ksiazka.ID}.\n" +
                        $"{ksiazka.tytul} - {ksiazka.Autor} \n" +
                        $"Rok Wydania: {ksiazka.RokWydania}, Gatunek: {ksiazka.Gatunek} \n" +
                        $"Cena: {ksiazka.Cena}, {ksiazka.Stan} ");

                        if(ksiazka.Wersja != WersjaKsiazki.Papierowa)
                            Console.Write($"Wersja : {ksiazka.Wersja}\n");
                        
                        if(ksiazka.narrator is not null)
                            Console.Write($"Narrator: {ksiazka.narrator}\n");

                        if (ksiazka.Wersja == WersjaKsiazki.Ebook)
                            Console.Write($"Rozmiar pliku: {ksiazka.RozmiarPliku}\n");
                                   
                }
            }
            else
            {
                Console.WriteLine("Brak książek w bazie danych.");
            }
            Console.WriteLine("Naciśnij Enter aby wrócić do menu...");
            Console.ReadLine();
            Main(null);
        }

        public static void WyszukajKsiazkePoTytule()
        {
            Console.Clear();
            string json = File.ReadAllText("ksiazki.json");
            List<Ksiazka> ksiazki = JsonConvert.DeserializeObject<List<Ksiazka>>(json);

            Console.WriteLine("Podaj tytuł książki: ");
            string szukanyTytul = Console.ReadLine();

            if (string.IsNullOrEmpty(szukanyTytul))
            {
                Console.WriteLine("Nie podano tytułu książki");
                Console.WriteLine("Naciśnij Enter aby wrócić do menu...");
                Console.ReadLine();
                Main(null);
            }

            bool czyZnaleziono = false;
            foreach (var ksiazka in ksiazki)
            {
                if (ksiazka.tytul.Equals(szukanyTytul, StringComparison.OrdinalIgnoreCase))
                {
                    czyZnaleziono = true;
                    Console.WriteLine(
                        $"{ksiazka.ID}.\n" +
                        $"{ksiazka.tytul} - {ksiazka.Autor} \n" +
                        $"Rok Wydania: {ksiazka.RokWydania}, Gatunek: {ksiazka.Gatunek} \n" +
                        $"Cena: {ksiazka.Cena}, {ksiazka.Stan}\n");

                    if (ksiazka is KsiazkaElektroniczna ksiazkaElektroniczna)
                    {
                        if (ksiazka.Wersja == WersjaKsiazki.Audiobook)
                        {
                            Console.WriteLine($"Narrator: {ksiazkaElektroniczna.narrator}");
                        }
                        else if (ksiazka.Wersja == WersjaKsiazki.Ebook)
                        {
                            Console.WriteLine($"Rozmiar: {ksiazkaElektroniczna.RozmiarPliku}");
                        }
                    }
                }
            }

            if (!czyZnaleziono)
            {
                Console.WriteLine("Nie znaleziono książki o podanym tytule");
            }
            Console.WriteLine("Naciśnij Enter aby wrócić do menu...");
            Console.ReadLine();
            Main(null);
        }

        public static void DodajKsiazke()
        {
            Console.Clear();
            string json = File.ReadAllText("ksiazki.json");
            List<Ksiazka> ksiazki = JsonConvert.DeserializeObject<List<Ksiazka>>(json);

            Console.WriteLine("Podaj tytuł książki: ");
            string tytul = Console.ReadLine();

            Console.WriteLine("\n Podaj autora książki: ");
            string autor = Console.ReadLine();

            Console.WriteLine("\n Podaj rok wydania książki: ");
            string rokWydania = Console.ReadLine();

            Console.WriteLine("\n Podaj gatunek książki: ");
            string gatunek = Console.ReadLine();

            Console.WriteLine("\n Podaj cenę książki: ");
            if (!float.TryParse(Console.ReadLine(), out float cena))
            {
                Console.WriteLine("Niepoprawna cena");
                Console.WriteLine("Naciśnij Enter aby wrócić do menu...");
                Console.ReadLine();
                Main(null);
            }

            Console.WriteLine("\n Podaj stan książki: ");
            string stan = Console.ReadLine();

            Console.WriteLine("\n Podaj wersję książki: ");
            Console.WriteLine("1) Papierowa");
            Console.WriteLine("2) Ebook");
            Console.WriteLine("3) Audiobook");

            if (!int.TryParse(Console.ReadLine(), out int wersja))
            {
                Console.WriteLine("Niepoprawna wersja");
                Console.WriteLine("Naciśnij Enter aby wrócić do menu...");
                Console.ReadLine();
                Main(null);
            }

            ksiazki.Add(new Ksiazka
            {
                ID = (ksiazki.Count + 1).ToString(),
                tytul = tytul,
                Autor = autor,
                RokWydania = rokWydania,
                Gatunek = gatunek,
                Cena = cena,
                Stan = stan,
                Wersja = (WersjaKsiazki)wersja
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
            List<Ksiazka> ksiazki = JsonConvert.DeserializeObject<List<Ksiazka>>(json);

            foreach (var ksiazka in ksiazki)
            {
                Console.WriteLine(
                    $"{ksiazka.ID}.\n" +
                    $"{ksiazka.tytul} - {ksiazka.Autor} \n" +
                    $"Rok Wydania: {ksiazka.RokWydania}, Gatunek: {ksiazka.Gatunek} \n" +
                    $"Cena: {ksiazka.Cena}, {ksiazka.Stan}\n");

                if (ksiazka is KsiazkaElektroniczna ksiazkaElektroniczna)
                {
                    if (ksiazka.Wersja == WersjaKsiazki.Audiobook)
                    {
                        Console.WriteLine($"Narrator: {ksiazkaElektroniczna.narrator}");
                    }
                    else if (ksiazka.Wersja == WersjaKsiazki.Ebook)
                    {
                        Console.WriteLine($"Rozmiar: {ksiazkaElektroniczna.RozmiarPliku}");
                    }
                }
            }

            Console.WriteLine("Podaj ID książki do usunięcia: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                Ksiazka ksiazkaDoUsuniecia = ksiazki.FirstOrDefault(x => x.ID == id.ToString());
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