using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillogoGomb
{
    internal class VillogoGomb : Button
    {
        Color eredeti;
        public VillogoGomb()
        {
            BackColor = eredeti;
            MouseEnter += VillogoGomb_MouseEnter;
            MouseLeave += VillogoGomb_MouseLeave;
        }


        private void VillogoGomb_MouseLeave(object? sender, EventArgs e)
        {
            BackColor = eredeti;
        }

        private void VillogoGomb_MouseEnter(object? sender, EventArgs e)
        {
            BackColor = Color.Fuchsia;
        }
    }
}
