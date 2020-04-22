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

namespace TP1_2019_2020
{
    [Serializable]
    public class MyPersonalMapData : INotifyPropertyChanged, IEquatable<MyPersonalMapData>
    {


        public String Nom { get; set; }
        public String Prénom { get; set; }
        private String Email{ get; set; }
        public ObservableCollection<ICartoObj> _data;
        public event PropertyChangedEventHandler PropertyChanged;


        public ObservableCollection<ICartoObj> Data
        {
            get => _data;
            set   {  _data= value;
                NotifyPropertyChanged();

            }
        }


        private void NotifyPropertyChanged ([CallerMemberName] string propertyname=null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
            }
        }


        public MyPersonalMapData(string nom, string prénom, string email, ObservableCollection<ICartoObj> data)
        {
            Nom = nom;
            Prénom = prénom;
            Email = email;
            Data = data;
        }

        public MyPersonalMapData()
        {
            Nom = "NULL";
            Prénom = "NULL";
            Email = "NULL";
            Data = new ObservableCollection<ICartoObj>();
        }





        public void SaveData()
        {
            BinaryFormatter binFormat = new BinaryFormatter();
            using (Stream fstream = new FileStream(@"" + Nom + Prénom + ".dat", FileMode.Append, FileAccess.Write, FileShare.None))
            {
                binFormat.Serialize(fstream, Data);
            }


         }


        public void ResetData()
        {
            Data.Clear();

        }

        public void LoadData(String s) 
        {
            BinaryFormatter binFormat = new BinaryFormatter();
            using (Stream fstream = new FileStream(s, FileMode.Open, FileAccess.Read, FileShare.None)) 
            {
                Data = (ObservableCollection < ICartoObj >)binFormat.Deserialize(fstream);
            }

        }



        public override string ToString()         // utilisé uniquement pour le debugging, peut être modifier au besoin
        {
            return Data.Count.ToString();
        }

        public bool Equals(MyPersonalMapData other)
        {
            if (!(this.Prénom.Equals(other.Prénom)) )   { return false; }
            if (!(this.Nom.Equals(other.Nom))) { return false; }
            if (!(this.Email.Equals(other.Email))) { return false; }
            if (!(this.Data.SequenceEqual(other.Data))) { return false; }    //   PEUT ETRE OURCE DE BUG ( ITERER LES COLLECTIONS MANUELMENET POUR POUVIR CASTER EN UTILISANT AS IS ??? )


            return true;
        }
    }
}
