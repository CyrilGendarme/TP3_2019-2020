using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TP3_2019_2020.Objetcs
{
    [Serializable]
    public class Produit : Contenu, INotifyPropertyChanged, IUseMot_clé
    {
        [field: NonSerialized]
        public new event PropertyChangedEventHandler PropertyChanged;

        private String _filePath;
        public String FilePath
        {
            get => _filePath;
            set
            {
                _filePath = value;
                NotifyPropertyChanged();
            }
        }

        private Mot_clé _mot_clé;
        public Mot_clé Mot_clé
        {
            get => _mot_clé;
            set
            {
                _mot_clé = value;
                NotifyPropertyChanged();
            }
        }

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

        private String _fournisseur;
        private double _prixAchat;
        private double _prixVente;

        public String Fournisseur
        {
            get => _fournisseur;
            set
            {
                _fournisseur = value;
                NotifyPropertyChanged();
            }
        }
        public double PrixAchat
        {
            get => _prixAchat;
            set
            {
                _prixAchat = value;
                NotifyPropertyChanged();
            }
        }
        public double PrixVente
        {
            get => _prixVente;
            set
            {
                _prixVente = value;
                NotifyPropertyChanged();
            }
        }



        // nous avons ici deux constructeur d'initialisation, un qui utilise un nom, l'autre qui utilise un mot-clé
        public Produit() : base()
        {
            Mot_clé = new Mot_clé();
            ListeCollections = new List<Collection>();
            Fournisseur = "NULL";
            PrixAchat = 0;
            PrixVente = 0;
            FilePath = "NULL";
        }

        public Produit(String nom, List<Collection> list, String fourni, double achat, double vente, String fp) : base(nom)
        {
            Mot_clé = new Mot_clé();
            ListeCollections = list;
            Fournisseur = fourni;
            PrixAchat = achat;
            PrixVente = vente;
            FilePath = fp;
        }

        public Produit(Mot_clé _mot_clé, List<Collection> list, String fourni, double achat, double vente, String fp) : base(_mot_clé.Nom)
        {
            Mot_clé = _mot_clé;
            ListeCollections = list;
            Fournisseur = fourni;
            PrixAchat = achat;
            PrixVente = vente;
            FilePath = fp;
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
            List<Mot_clé> ListToBuild = new List<Mot_clé>();
            ListToBuild.Add(Mot_clé);
            return ListToBuild;
        }


        public override String ToString()
        {
            return Nom + " (produit)";
        }
    }
}
