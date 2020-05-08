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
    public class MyCollectionStructure : INotifyPropertyChanged
    {
        [field: NonSerialized]
        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<CollectionGroup> _listCollectionGroup;

        public ObservableCollection<CollectionGroup> ListCollectionGroup
        {
            get => _listCollectionGroup;
            set
            {
                _listCollectionGroup = value;
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

        public MyCollectionStructure()
        {
            ListCollectionGroup = new ObservableCollection<CollectionGroup>();

        }


    }
}
