using EierfarmBl;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EierfarmMvvmUi
{
    public class ViewModel : INotifyPropertyChanged
    {
        public ViewModel()
        {
            this.NeuesHuhnCommand = new RelayCommand(p => KannNeuesHuhn(), a => NeuesHuhn());
            this.NeueGansCommand = new RelayCommand(p => KannNeueGans(), a => NeueGans());
            this.TierFuetternCommand = new RelayCommand(p => KannFuettern(), a => TierFuettern(a)); // Beispielhaft: RelayCommand mit Parameter (CommandParameter-Binding im XAML nicht vergessen!)
            this.TierEiLegenLassenCommand = new RelayCommand(p => KannEiLegen(), a => TierEiLegenLassen());
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        private bool KannEiLegen()
        {
            return SelectedTier?.Gewicht > SelectedTier?.MinEiLegeGewicht;
        }

        private void TierEiLegenLassen()
        {
            SelectedTier.EiLegen();
        }

        private bool KannFuettern()
        {
            return SelectedTier?.Gewicht < SelectedTier?.MaxFressGewicht;
        }

        private void TierFuettern(object tier)
        {
            //Gefluegel gefluegel = tier as Gefluegel; // SaveCast -> null, wenn Cast fehlschlägt
            //if (gefluegel!=null)
            //{

            //}
            (tier as Gefluegel)?.Fressen();
        }

        private bool KannNeueGans()
        {
            return true;
        }

        private void NeueGans()
        {
            this.Tiere.Add(new Gans());
            this.SelectedTier = this.Tiere.Last();
        }

        private bool KannNeuesHuhn()
        {
            return true;
        }

        private void NeuesHuhn()
        {
            this.Tiere.Add(new Huhn());
            this.SelectedTier = this.Tiere.Last();
        }

        public ObservableCollection<Gefluegel> Tiere { get; set; } = new ObservableCollection<Gefluegel>();

        private Gefluegel _selectedTier;

        public Gefluegel SelectedTier
        {
            get { return _selectedTier; }
            set
            {
                _selectedTier = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand NeuesHuhnCommand { get; set; }
        public RelayCommand NeueGansCommand { get; set; }
        public RelayCommand TierFuetternCommand { get; set; }
        public RelayCommand TierEiLegenLassenCommand { get; set; }
    }
}
