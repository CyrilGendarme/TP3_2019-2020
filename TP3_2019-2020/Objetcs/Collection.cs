﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TP3_2019_2020.Objetcs
{
    [Serializable]
    public class Collection : Contenu, INotifyPropertyChanged, IUseMot_clé
    {
        [field: NonSerialized]
        public new event PropertyChangedEventHandler PropertyChanged;

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



        public Collection() : base()
        {
            Mot_clé = new Mot_clé();
            ListeProduits = new List<Produit>();
        }

        public Collection(Mot_clé mot_clé, List<Produit> list) : base (mot_clé.Nom)
        {
            Mot_clé = mot_clé;
            ListeProduits = list;
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
            foreach (Produit prod in ListeProduits)
            {
                ListToBuild.Add(prod.Mot_clé);
            }
            Mot_cléComparer comparer = new Mot_cléComparer();
            ListToBuild.Distinct(comparer);
            return ListToBuild;
        }

        public override String ToString()
        {
            return Nom + " (collection)";
        }
    }
}
