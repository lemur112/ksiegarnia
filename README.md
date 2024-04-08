# ksiegarnia

Aplikacja umożliwia użytkownikowi wybór różnych opcji, takich jak wyświetlanie wszystkich książek, wyszukiwanie książek po tytule, dodawanie nowych książek i usuwanie istniejących książek.

Główna funkcja Main jest punktem wejścia do programu. Po wyczyszczeniu konsoli, wyświetla ona menu z dostępnymi opcjami. Użytkownik może wprowadzić numer opcji, a następnie program używa instrukcji switch do wywołania odpowiedniej funkcji w zależności od wybranej opcji.

Funkcja WyswietlWszystkieKsiazki wczytuje dane z pliku JSON zawierającego informacje o książkach, a następnie wyświetla je na konsoli. Każda książka jest wyświetlana w oddzielnym wierszu, zawierającym jej ID, tytuł, autora, rok wydania i gatunek.

Funkcja WyszukajKsiazkePoTytule umożliwia użytkownikowi wyszukanie książki po tytule. Po wczytaniu danych z pliku JSON, użytkownik jest proszony o wprowadzenie tytułu książki. Następnie program przeszukuje listę książek i wyświetla te, których tytuł zawiera wprowadzony ciąg znaków. Jeśli nie zostanie znaleziona żadna książka, program wyświetla odpowiedni komunikat.

Funkcja DodajKsiazke umożliwia użytkownikowi dodanie nowej książki do listy. Użytkownik jest proszony o wprowadzenie tytułu, autora, roku wydania i gatunku książki. Następnie program tworzy nowy obiekt JsonModel reprezentujący książkę i dodaje go do listy książek. Lista jest następnie zapisywana z powrotem do pliku JSON.

Funkcja UsunKsiazke umożliwia użytkownikowi usunięcie książki z listy. Program wyświetla wszystkie książki wraz z ich ID, a następnie prosi użytkownika o wprowadzenie ID książki do usunięcia. Jeśli podane ID istnieje w liście książek, program usuwa odpowiednią książkę z listy i zapisuje zmienioną listę z powrotem do pliku JSON.
Wszystkie funkcje kończą się wywołaniem funkcji Main(null), co powoduje powrót do menu głównego po wykonaniu wybranej operacji.



