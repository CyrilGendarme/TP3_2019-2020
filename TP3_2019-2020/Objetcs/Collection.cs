using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP3_2019_2020.Objetcs
{
    public class Collection : Contenu
    {

        public event PropertyChangedEventHandler PropertyChanged;

        public Mot_clé mot_clé { get; set; }

        private List<Produit> _listeProduits;
        public List<Produit> ListeProduits
        {
            get => _listeProduits;
            set
            {
                _listeProduits = value;
                NotifyPropertyChanged();
            }
        }
    }
}
