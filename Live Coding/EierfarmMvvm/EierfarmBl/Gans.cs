using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EierfarmBl
{
    public class Gans : Gefluegel
    {
        public Gans() : base("Neue Gans")
        {
            this.Gewicht = 2000;
            this.MinEiLegeGewicht = 2000;
            this.MaxFressGewicht = 5000;
        }

        public override void EiLegen()
        {
            if (this.Gewicht > MinEiLegeGewicht)
            {
                Ei ei = new Ei(this);
                this.Eier.Add(ei);
                this.Gewicht -= ei.Gewicht;
            }
        }

        public override void Fressen()
        {
            if (this.Gewicht < MaxFressGewicht)
            {
                this.Gewicht += 250;
            }
        }
    }
}
