using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace TP3_2019_2020.Objetcs
{
    [Serializable]
    public class Article : Contenu, INotifyPropertyChanged, IUseMot_clé
    {
        [field: NonSerialized]
        public new event PropertyChangedEventHandler PropertyChanged;

        private List<Mot_clé> _listeMotClé;
        public List<Mot_clé> ListeMotClé
        {
            get => _listeMotClé;
            set
            {
                _listeMotClé = value;
                NotifyPropertyChanged();
            }
        }

        private double _qualité; // valeur comprise entre 0 et 100
        public double Qualité
        {
            get => _qualité;
            set
            {
                if (value <= 100 && value >= 0) _qualité = value;
                else
                {
                    DialogResult result;
                    result = MessageBox.Show("La qualité doit être comprise entre 0 et 100", "Erreur de valeur", MessageBoxButtons.OK);
                }
            }
        }

        private List<String> _liensSortants;
        public List<String> LiensSortants
        {
            get => _liensSortants;
            set
            {
                _liensSortants = value;
                NotifyPropertyChanged();
            }
        }





        public Article() : base()
        {
            ListeMotClé = new List<Mot_clé>();
            Qualité = 0;
            LiensSortants = new List<String>();
        }

        public Article(String titre, List<Mot_clé> listMot, double quali, List<String> listLiens) : base(titre)
        {
            ListeMotClé = new List<Mot_clé>();
            Qualité = quali;
            LiensSortants = listLiens;
        }







        private void NotifyPropertyChanged([CallerMemberName] string propertyname = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
            }
        }

        public List<Mot_clé> getAllMotClé()
        {
            return ListeMotClé;
        }

        public override String ToString()
        {
            return Nom + " (article)";
        }
    }
}
