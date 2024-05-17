using System.ComponentModel.DataAnnotations;

namespace ksiegarnia
{
    public class Ksiazka
    {
        public string ID { get; set; }
        public string tytul { get; set; }
        public string Autor { get; set; }
        public string RokWydania { get; set; }
        public string Gatunek { get; set; }
        public float Cena { get; set; }
        public string Stan { get; set; }

        public WersjaKsiazki Wersja { get; set; }

       
    }

    public enum WersjaKsiazki
    {
        Papierowa,
        Ebook,
        Audiobook
    }

    public class KsiazkaElektroniczna : Ksiazka
    {
        public string RozmiarPliku { get; set; }
        public format_pliku Format { get; set; }
        public string narrator { get; set; }
    }

    public enum format_pliku
    {
        PDF,
        MP3,
        EPUB,
        MOBI
    }
}
