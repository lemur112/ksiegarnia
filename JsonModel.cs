using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ksiegarnia
{
    internal class JsonModel
    {
        public required int ID { get; set; }
        public required string tytul { get; set; }
        public required string Autor { get; set; }
        public required DateTime RokWydania { get; set; }
        public required string Gatunek { get; set; }
    }
}
