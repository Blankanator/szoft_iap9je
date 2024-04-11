using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adatkotes
{
    public class CountryData /*internal to public*/
    {
        //Name,Population,AreaInSquareKm
        public string Name { get; set; } = string.Empty; // = ""; //kezdo ertek stringnek, kulondben 0 lesz,a mi nem string
        public long Population { get; set; }
        public double AreaInSquareKm { get; set; }

    }
}
