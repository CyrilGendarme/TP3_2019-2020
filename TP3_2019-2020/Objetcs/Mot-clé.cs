using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP3_2019_2020.Objetcs
{
    public class Mot_clé : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public String Nom { get; set; }
        public int Volume { get; set; }

        private double _difficulté; // valeur comprise entre 0 et 100
        public double Difficulté
        {
            get => _difficulté;
            set
            {
                if (value <= 100 && value >= 0) _difficulté = value;
                else
                {
                    DialogResult result;
                    result = MessageBox.Show("La difficulté doit être comprise entre 0 et 100", "Erreur de valeur", MessageBoxButtons.OK);
                }
            }
        }


        public Mot_clé()
        {
            Nom = "NULL";
            Volume = 0;
            Difficulté = 100;
        }

        public Mot_clé(String s, int v, double d)
        {
            Nom = s;
            Volume = v;
            Difficulté = d;
        }

        private void NotifyPropertyChanged([CallerMemberName] string propertyname = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
            }
        }


        public override String ToString()
        {
            return Nom; 
        }



    }
}
