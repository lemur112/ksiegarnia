using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ksiegarnia
{
    public class JsonModel
    {
        
            public required string ID { get; set; }
            public required string tytul { get; set; }
            public required string Autor { get; set; }
            public required string RokWydania { get; set; }
            public required string Gatunek { get; set; }
        
        
    }
}
