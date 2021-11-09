using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EierfarmBl
{
    public class Ei
    {
        public Ei(Gefluegel mutter)
        {
            this.Mutter = mutter;
            this.Legedatum = DateTime.Now;

            Random random = new Random();
            this.Gewicht = random.Next(45, 81);
            this.Farbe = (EiFarbe)random.Next(Enum.GetNames(typeof(EiFarbe)).Length);
        }

        public Gefluegel Mutter { get;  set; }
        public DateTime Legedatum { get; }
        public double Gewicht { get; set; }
        public EiFarbe Farbe { get; set; }
    }

    public enum EiFarbe
    {
        Hell,
        Dunkel,
        Gruen
    }
}
