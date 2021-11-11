using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EierfarmBl
{
    public class Huhn : Gefluegel
    {
        public Huhn() : base("Neues Huhn")
        {
            this.Gewicht = 1000;
            this.MinEiLegeGewicht = 1500;
            this.MaxFressGewicht = 3000;
        }

        public override void EiLegen()
        {
            if (this.Gewicht > this.MinEiLegeGewicht)
            {
                Ei ei = new Ei(this);
                this.Eier.Add(ei);
                this.Gewicht -= ei.Gewicht;
            }
        }

        public override void Fressen()
        {
            if (this.Gewicht < this.MaxFressGewicht)
            {
                this.Gewicht += 100;
            }
        }
    }
}
