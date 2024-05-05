using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ksiegarnia
{
    public class Ksiazka
    {
            public required string ID { get; set; }
            public required string tytul { get; set; }
            public string Autor { get; set; }
            public string RokWydania { get; set; }
            public string Gatunek { get; set; }
            public float Cena { get; set; }
            public required string Stan { get; set; }
            public required WersjaKsiazki Wersja { get; set; }
            
        
    }

    public enum WersjaKsiazki
    {         
        Papierowa,
        Ebook,
        Audiobook
    }

    public class KsiazkaElektroniczna : Ksiazka
    {
        public required string rozmiar { get; set; }
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
