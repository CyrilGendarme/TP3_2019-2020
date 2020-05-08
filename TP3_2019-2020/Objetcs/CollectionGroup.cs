

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
    public class CollectionGroup : Contenu, INotifyPropertyChanged
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

        private List<Collection> _listeCollection;
        public List<Collection> ListeCollection
        {
            get => _listeCollection;
            set
            {
                _listeCollection = value;
                NotifyPropertyChanged();
            }
        }



        public CollectionGroup() : base()
        {
            Mot_clé = new Mot_clé();
            ListeCollection = new List<Collection>();
        }

        public CollectionGroup(Mot_clé mot_clé, List<Collection> list)
        {
            Nom = mot_clé.Nom;
            Mot_clé = mot_clé;
            ListeCollection = list;
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
            return Nom + " (Groupe de collection)";
        }
    }
}
