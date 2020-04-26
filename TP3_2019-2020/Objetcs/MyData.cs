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
    class MyData : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Thématique> _listThémattique;
        public ObservableCollection<Collection> _listCollection;
        public ObservableCollection<Produit> _listProduit;
        public ObservableCollection<Article> _listArticle;
        public ObservableCollection<Mot_clé> _listMotClé;






        private void NotifyPropertyChanged([CallerMemberName] string propertyname = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
            }
        }




        public void SaveData()
        {
            BinaryFormatter binFormat = new BinaryFormatter();
            using (Stream fstream = new FileStream(@"" + "MyWebsiteData.dat", FileMode.Create, FileAccess.Write, FileShare.None))
            {
                binFormat.Serialize(fstream, Data);
            }


        }

        public void LoadData(String s)
        {
            BinaryFormatter binFormat = new BinaryFormatter();
            using (Stream fstream = new FileStream(s, FileMode.Open, FileAccess.Read, FileShare.None))
            {
                Data = (ObservableCollection<ICartoObj>)binFormat.Deserialize(fstream);
            }

        }


    }
}
