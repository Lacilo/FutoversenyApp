using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FutoversenyApp.Models
{
    internal class Display
    {
        internal List<Futas> Futasok { get => Futasok; set => Futasok = value; }

        public Display(List<Futas> futasok)
        {
            Futasok = futasok;
        }

        void UpdateFutasok(List<Futas> ujFutasok)
        {
            this.Futasok = ujFutasok;
        }
    }
}
