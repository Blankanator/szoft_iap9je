using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KigyosJatek
{

    internal class Alma : PictureBox
    {
        public static int Meret = 20;

        public Alma()
        {
            Width = Alma.Meret;
            Height = Alma.Meret;
            BackColor = Color.Red;
        }
    }

}
