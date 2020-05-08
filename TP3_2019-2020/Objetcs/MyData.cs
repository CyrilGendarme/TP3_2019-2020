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
using System.Xml.Serialization;

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
        public ObservableCollection<String> _listPhrases;
        public MyCollectionStructure _colstruct;
        public string FilePath { get; set; }


        public MyCollectionStructure Colstruct
        {
            get => _colstruct;
            set
            {
                _colstruct = value;
                NotifyPropertyChanged();

            }
        }

        public ObservableCollection<Thématique> ListThématique
        {
            get => _listThématique;
            set
            {
                _listThématique = value;
                NotifyPropertyChanged();

            }
        }

        public ObservableCollection<String> ListPhrases
        {
            get => _listPhrases;
            set
            {
                _listPhrases = value;
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
            ListPhrases = new ObservableCollection<String>();
            Colstruct = new MyCollectionStructure();
        }


        public void SaveData()
        {
                TextWriter writer = null;
                try
                {
                    var serializer = new XmlSerializer(typeof(MyData));
                    writer = new StreamWriter(FilePath, false);
                    serializer.Serialize(writer, this);
                }
                finally
                {
                    if (writer != null)
                        writer.Close();
                }
        }

        public void LoadData(String path)
        {
            TextReader reader = null;
            try
            {
                var serializer = new XmlSerializer(typeof(MyData));
                reader = new StreamReader(path);
                MyData temp = (MyData)serializer.Deserialize(reader);
                ListMotClé = temp.ListMotClé;
                ListCollection = temp.ListCollection;
                ListProduit = temp.ListProduit;
                ListArticle = temp.ListArticle;
                ListThématique = temp.ListThématique;
                Colstruct = temp.Colstruct;
                FilePath = temp.FilePath;

            }
            finally
            {
                if (reader != null)
                    reader.Close();
            }
        }
    }
}
