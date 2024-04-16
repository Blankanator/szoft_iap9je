using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MintaZH2
{
    public class FutokData
    {
        public int VersenyzoID { get; set; } 
        public string Nev { get; set; } = string.Empty;
        public string Nemzetiseg { get; set; } = string.Empty;
        public int EredmenyPerc { get; set; }
        public string Kategoria { get; set; } = string.Empty;
    }
}
