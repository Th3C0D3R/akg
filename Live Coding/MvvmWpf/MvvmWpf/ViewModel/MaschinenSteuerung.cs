using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvvmWpf
{
    public class MaschinenSteuerung
    {
        public MaschinenSteuerung()
        {
            this.Maschine = new TennisballWurfmaschine();

            this.StartCommand = new RelayCommand(p => MaschineKannStarten(), a => MaschineStarten());
            this.StoppCommand = new RelayCommand(p => MaschineKannStoppen(), a => MaschineStoppen());
        }

        private bool MaschineKannStoppen()
        {
            return Maschine.IstAmLaufen;
        }

        private void MaschineStoppen()
        {
            this.Maschine.Stopp();
        }

        private bool MaschineKannStarten()
        {
            return !Maschine.IstAmLaufen;
        }

        private void MaschineStarten()
        {
            this.Maschine.Start();
        }

        public TennisballWurfmaschine Maschine { get; set; }

        public RelayCommand StartCommand { get; set; }
        public RelayCommand StoppCommand { get; set; }
    }
}
