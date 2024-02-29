using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillogoGomb
{
    internal class SzamoloGomb : SzinezodoGomb
    {
        int szam = 0;
        public SzamoloGomb()
        {
            Width = 20;
            Height = 20;

            MouseClick += SzamoloGomb_MouseClick;

        }

        private void SzamoloGomb_MouseClick(object? sender, MouseEventArgs e)
        {
            szam += 1;
            if (szam > 5)
            {
                szam = 1;
            }
            Text = (szam).ToString();
        }
    }
}
