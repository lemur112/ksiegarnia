# ksiegarnia

Aplikacja umożliwia użytkownikowi wybór różnych opcji, takich jak wyświetlanie wszystkich książek, wyszukiwanie książek po tytule, dodawanie nowych książek i usuwanie istniejących książek.

Główna funkcja Main jest punktem wejścia do programu. Po wyczyszczeniu konsoli, wyświetla ona menu z dostępnymi opcjami. Użytkownik może wprowadzić numer opcji, a następnie program używa instrukcji switch do wywołania odpowiedniej funkcji w zależności od wybranej opcji.

![image](https://github.com/lemur112/Books-Managment/assets/105245169/2535133d-18fc-41a2-b175-a239aede1a9f)


Funkcja WyswietlWszystkieKsiazki wczytuje dane z pliku JSON zawierającego informacje o książkach, a następnie wyświetla je na konsoli. Każda książka jest wyświetlana w oddzielnym wierszu, zawierającym jej ID, tytuł, autora, rok wydania i gatunek.

![image](https://github.com/lemur112/Books-Managment/assets/105245169/92bc7893-d696-4656-aadd-9952edc84053)


Funkcja WyszukajKsiazkePoTytule umożliwia użytkownikowi wyszukanie książki po tytule. Po wczytaniu danych z pliku JSON, użytkownik jest proszony o wprowadzenie tytułu książki. Następnie program przeszukuje listę książek i wyświetla te, których tytuł zawiera wprowadzony ciąg znaków. Jeśli nie zostanie znaleziona żadna książka, program wyświetla odpowiedni komunikat.

![image](https://github.com/lemur112/Books-Managment/assets/105245169/20e70c68-78f7-4e63-80c3-13ccea4246d2)

Funkcja DodajKsiazke umożliwia użytkownikowi dodanie nowej książki do listy. Użytkownik jest proszony o wprowadzenie tytułu, autora, roku wydania i gatunku książki. Następnie program tworzy nowy obiekt JsonModel reprezentujący książkę i dodaje go do listy książek. Lista jest następnie zapisywana z powrotem do pliku JSON.

![image](https://github.com/lemur112/Books-Managment/assets/105245169/fdd3046e-f5cf-40d3-b68c-de576ac3bd88)
![image](https://github.com/lemur112/Books-Managment/assets/105245169/0374bb72-d903-41d5-b78e-9a2a8bb9784e)


Funkcja UsunKsiazke umożliwia użytkownikowi usunięcie książki z listy. Program wyświetla wszystkie książki wraz z ich ID, a następnie prosi użytkownika o wprowadzenie ID książki do usunięcia. Jeśli podane ID istnieje w liście książek, program usuwa odpowiednią książkę z listy i zapisuje zmienioną listę z powrotem do pliku JSON.
Wszystkie funkcje kończą się wywołaniem funkcji Main(null), co powoduje powrót do menu głównego po wykonaniu wybranej operacji.

![image](https://github.com/lemur112/Books-Managment/assets/105245169/1747d4e0-538b-4719-8d1d-3e308700c878)
![image](https://github.com/lemur112/Books-Managment/assets/105245169/b0bdfe59-4619-4f92-90f2-1ade99066b89)




