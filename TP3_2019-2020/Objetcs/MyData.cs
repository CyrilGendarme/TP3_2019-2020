using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace TP3_2019_2020.Objetcs
{

    [Serializable]
    public class MyData : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Thématique> _listThématique;
        public ObservableCollection<Collection> _listCollection;
        public ObservableCollection<Produit> _listProduit;
        public ObservableCollection<Article> _listArticle;
        public ObservableCollection<Mot_clé> _listMotClé;

        public ObservableCollection<Thématique> ListThématique
        {
            get => _listThématique;
            set
            {
                _listThématique = value;
                NotifyPropertyChanged();

            }
        }
        public ObservableCollection<Collection> ListCollection
        {
            get => _listCollection;
            set
            {
                _listCollection = value;
                NotifyPropertyChanged();

            }
        }
        public ObservableCollection<Produit> ListProduit
        {
            get => _listProduit;
            set
            {
                _listProduit = value;
                NotifyPropertyChanged();

            }
        }
        public ObservableCollection<Article> ListArticle
        {
            get => _listArticle;
            set
            {
                _listArticle = value;
                NotifyPropertyChanged();

            }
        }
        public ObservableCollection<Mot_clé> ListMotClé
        {
            get => _listMotClé;
            set
            {
                _listMotClé = value;
                NotifyPropertyChanged();

            }
        }





        private void NotifyPropertyChanged([CallerMemberName] string propertyname = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
            }
        }

        public MyData()
        {
            ListMotClé = new ObservableCollection<Mot_clé>();
            ListProduit = new ObservableCollection<Produit>();
            ListArticle = new ObservableCollection<Article>();
            ListCollection = new ObservableCollection<Collection>();
            ListThématique = new ObservableCollection<Thématique>();
        }


        public void SaveData()
        {
            BinaryFormatter binFormat = new BinaryFormatter();
            using (Stream fstream = new FileStream(@"" + "MyWebsiteMotClé.dat", FileMode.Create, FileAccess.Write, FileShare.None))
            {
                binFormat.Serialize(fstream, ListMotClé);
            }
            using (Stream fstream = new FileStream(@"" + "MyWebsiteArticle.dat", FileMode.Create, FileAccess.Write, FileShare.None))
            {
                binFormat.Serialize(fstream, ListArticle);
            }
            using (Stream fstream = new FileStream(@"" + "MyWebsiteProduit.dat", FileMode.Create, FileAccess.Write, FileShare.None))
            {
                binFormat.Serialize(fstream, ListProduit);
            }
            using (Stream fstream = new FileStream(@"" + "MyWebsiteCollection.dat", FileMode.Create, FileAccess.Write, FileShare.None))
            {
                binFormat.Serialize(fstream, ListCollection);
            }
            using (Stream fstream = new FileStream(@"" + "MyWebsiteThématique.dat", FileMode.Create, FileAccess.Write, FileShare.None))
            {
                binFormat.Serialize(fstream, ListThématique);
            }


        }

        public void LoadData()
        {
            BinaryFormatter binFormat = new BinaryFormatter();
            using (Stream fstream = new FileStream(@"" + "MyWebsiteMotClé.dat", FileMode.Open, FileAccess.Read, FileShare.None))
            {
                ListMotClé = (ObservableCollection<Mot_clé>)binFormat.Deserialize(fstream);
            }
            using (Stream fstream = new FileStream(@"" + "MyWebsiteArticle.dat", FileMode.Open, FileAccess.Read, FileShare.None))
            {
                ListProduit = (ObservableCollection<Produit>)binFormat.Deserialize(fstream);
            }
            using (Stream fstream = new FileStream(@"" + "MyWebsiteProduit.dat", FileMode.Open, FileAccess.Read, FileShare.None))
            {
                ListArticle = (ObservableCollection<Article>)binFormat.Deserialize(fstream);
            }
            using (Stream fstream = new FileStream(@"" + "MyWebsiteCollection.dat", FileMode.Open, FileAccess.Read, FileShare.None))
            {
                ListCollection = (ObservableCollection<Collection>)binFormat.Deserialize(fstream);
            }
            using (Stream fstream = new FileStream(@"" + "MyWebsiteThématique.dat", FileMode.Open, FileAccess.Read, FileShare.None))
            {
                ListThématique = (ObservableCollection<Thématique>)binFormat.Deserialize(fstream);
            }

        }


    }
}
