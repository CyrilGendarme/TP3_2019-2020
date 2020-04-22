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

        private List<Collection> _listeCollections;
        public List<Collection> ListeCollections
        {
            get => _listeCollections;
            set
            {
                _listeCollections = value;
                NotifyPropertyChanged();
            }
        }

        public String Fournisseur { get; set; }
        public double PrixAchat { get; set; }
        public double PrixVente { get; set; }



        // nous avons ici deux constructeur d'initialisation, un qui utilise un nom, l'autre qui utilise un mot-clé
        public Produit() : base()
        {
            mot_clé = new Mot_clé();
            ListeCollections = new List<Collection>();
            Fournisseur = "NULL";
            PrixAchat = 0;
            PrixVente = 0;
        }

        public Produit(String nom, List<Collection> list, String fourni, double achat, double vente) : base(nom)
        {
            mot_clé = new Mot_clé();
            ListeCollections = list;
            Fournisseur = fourni;
            PrixAchat = achat;
            PrixVente = vente;
        }

        public Produit(Mot_clé _mot_clé, List<Collection> list, String fourni, double achat, double vente) : base(_mot_clé.Nom)
        {
            mot_clé = _mot_clé;
            ListeCollections = list;
            Fournisseur = fourni;
            PrixAchat = achat;
            PrixVente = vente;
        }


        private void NotifyPropertyChanged([CallerMemberName] string propertyname = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
            }
        }
    }
}
