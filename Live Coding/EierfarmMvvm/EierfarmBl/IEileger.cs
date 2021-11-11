using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace EierfarmBl
{
    public interface IEileger
    {
        ObservableCollection<Ei> Eier { get; set; }
        double Gewicht { get; set; }

        void EiLegen();
    }
}