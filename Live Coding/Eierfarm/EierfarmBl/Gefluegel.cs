using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EierfarmBl
{
    public abstract class Gefluegel
    {

        public Gefluegel(string name)
        {
            this.Name = name;
        }

        public double Gewicht { get; set; }
        public string Name { get; set; }
        public Guid Id { get; set; } = Guid.NewGuid();
        public List<Ei> Eier { get; set; } = new List<Ei>();

        public abstract void Fressen();
        public abstract void EiLegen();
    }

}
