using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KigyosJatek
{
    internal class KigyoElem : PictureBox
    {
        public static int Meret = 20;

        public KigyoElem()
        {
            Width = KigyoElem.Meret;
            Height = KigyoElem.Meret;
            BackColor = Color.Green;
        }
    }
}
