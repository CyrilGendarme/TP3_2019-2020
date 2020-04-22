using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace TP1_2019_2020
{
    [Serializable]
    public class POI : Coordonnees, ICartoObj, INotifyPropertyChanged
    {
        private String _desc;
        public new event PropertyChangedEventHandler PropertyChanged;

        public String Desc
        {
            get => _desc;
            set
            {
                _desc = value;
                NotifyPropertyChanged();
            }
        }

        public POI() : base(17.5, 20.87)         // values choosen to represent the HEPL site
        {
            Desc = "HEPL";
        }
        public POI(String desc, double lat, double longi) : base(lat, longi)
        {
            Desc = desc;
        }



        public override String ToString()
        {
            return base.ToString()  + "\tDescription = " + Desc; 
        }

        private void NotifyPropertyChanged([CallerMemberName] string propertyname = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
            }
        }



        public void SaveObjet()
        {
            BinaryFormatter binFormat = new BinaryFormatter();
            using (Stream fstream = new FileStream(@"" + Desc + ".dat", FileMode.Append, FileAccess.Write, FileShare.None))
            {
                binFormat.Serialize(fstream, this);
            }


        }



        //public void LoadObjet(String s)
        //{
        //    BinaryFormatter binFormat = new BinaryFormatter();
        //    using (Stream fstream = new FileStream(s, FileMode.Open, FileAccess.Read, FileShare.None))
        //    {
        //        POI loaded = (POI)binFormat.Deserialize(fstream);
        //        this.Desc = loaded.Desc;
        //        this.Id = loaded.Id;
        //        this.Latitude = loaded.Latitude;
        //        this.Longitude = loaded.Latitude;
        //    }

        //}


    }
}
