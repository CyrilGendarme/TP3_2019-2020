using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TP3_2019_2020.Objetcs
{
    public class Produit : Contenu, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public Mot_clé mot_clé { get; set; }
        public list

        private double _difficulté; // valeur comprise entre 0 et 100
        public double Difficulté;







        private void NotifyPropertyChanged([CallerMemberName] string propertyname = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
            }
        }
    }
}
