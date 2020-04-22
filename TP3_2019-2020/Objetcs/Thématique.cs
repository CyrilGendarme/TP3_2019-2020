using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TP3_2019_2020.Objetcs
{
    public class Thématique : INotifyPropertyChanged, IUseMot_clé
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public Collection Collection { get; set; }

        private List<Article> _listeArticles;
        public List<Article> ListeArticles
        {
            get => _listeArticles;
            set
            {
                _listeArticles = value;
                NotifyPropertyChanged();
            }
        }



        public Thématique()
        {
            Collection = new Collection();
            ListeArticles = new List<Article>();
        }

        public Thématique(Collection col, List<Article> list) 
        {
            Collection = col;
            ListeArticles = list;
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
            ListToBuild.Add(Collection.Mot_clé);
            foreach (Article art in ListeArticles)
            {
                ListToBuild.AddRange(art.getAllMotClé());
            }
            Mot_cléComparer comparer = new Mot_cléComparer();
            ListToBuild.Distinct(comparer);
            return ListToBuild;

        }

        public override String ToString()
        {
            return Collection.Nom + " (thématique)";
        }
    }
}
