using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillogoGomb
{
    internal class SzinezodoGomb : Button
    {
        public SzinezodoGomb()
        {
            Width = 20;
            Height = 20;
            MouseClick += SzinezodoGomb_MouseClick;
        }

        private void SzinezodoGomb_MouseClick(object? sender, MouseEventArgs e)
        {
            BackColor = Color.Fuchsia;
        }
    }
}
