using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using System.Windows.Media;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace TP1_2019_2020
{
    [Serializable]
    public class Polyline : CartoObj, IIsPointClose, IPointy, IComparable<Polyline>, IEquatable<Polyline>, ICartoObj, INotifyPropertyChanged
    {
        public new event PropertyChangedEventHandler PropertyChanged;
        private List<Coordonnees> _data;
        private ColorSerializer _couleur;
        private int _epaisseur;


        public List<Coordonnees> Data 
        {
            get => _data;
            set
            {
                _data = value;
                NotifyPropertyChanged();
            }
        }

        public ColorSerializer Couleur 
        {
            get => _couleur;
            set
            {
                _couleur = value;
                NotifyPropertyChanged();
            }
        }

        public int Epaisseur
        {
            get => _epaisseur;
            set
            {
                _epaisseur = value;
                NotifyPropertyChanged();
            }
        }


        public Polyline() : base()
        {
            Data = new List<Coordonnees>();
            Couleur = new ColorSerializer();
            Epaisseur = 0;
        }

        public Polyline(List<Coordonnees> data, Color color, int epaisseur) : base()
        {
            Data = data;
            Couleur = new ColorSerializer(color);
            Epaisseur = epaisseur;
        }






        public override String ToString() {
 
            String ligne = "\tCouleur = " + Couleur + "\tEpaisseur = " + Epaisseur + "\tNombre de points = " + this.NbPoints() + "\nListe de données :";

            /*
            foreach (Coordonnees coord in Data)
            {
                ligne = ligne + "\n" + coord.ToString();
       
            }

            if (Data.Count == 0) ligne = ligne + "Null";
            */

            return base.ToString() + ligne;
        }

        public override void Draw() { Console.WriteLine(this.ToString()); }



        public double GetLongueurTotale()
        {
            double longueur=0, x1, x2, y1, y2;

            for (int i = 0; i < (this.Data.Count-1); i++)
            {
                x1 = this.Data[i].Latitude;
                y1 = this.Data[i].Longitude;
                x2 = this.Data[i + 1].Latitude;
                y2 = this.Data[i + 1].Longitude;
                longueur = longueur + MathUtil.Dist2Pt(x1, y1, x2, y2);
            }

            return longueur;
            
        }

        public double GetBoundingBoxArea()
        {

            // limites des valeurs de la fenetre de l application
            double xmin = 9999999;
            double xmax = -9999999;
            double ymin = 9999999;
            double ymax = -9999999;
            double surface = 0;

            foreach (Coordonnees coord in this.Data)
            {

                if (coord.Latitude < xmin)  xmin = coord.Latitude;
                
                if (coord.Latitude > xmax)  xmax = coord.Latitude;
                
                if (coord.Longitude < ymin) ymin = coord.Longitude;
                
                if (coord.Longitude > ymax) ymax = coord.Longitude; 
                
            }

            surface = (xmax - xmin) * (ymax - ymin);

            return surface;
        }




        public int CompareTo(Polyline polyl)
        {

            if (this.GetLongueurTotale() == polyl.GetLongueurTotale()) return 0;
            else if (this.GetLongueurTotale() < polyl.GetLongueurTotale()) return -1;
            else return 1;

        }

        public bool IsPointCLose(double x, double y, double précision)
        {

            // comparaison à chaque point de l objet polyline
            foreach (Coordonnees coord in Data)
            {
                 if ( MathUtil.Dist2Pt(coord.Latitude, coord.Longitude, x, y) <= précision) return true;
            }

            // comparaison à chaque segment de droite
            for (int i = 0; i < (Data.Count-1); i++)
            {
                if (MathUtil.DistPtDroite(Data[i], Data[i + 1], x, y) <= précision) return true;
            }

            return false;
            
        }

        public bool Equals(Polyline pol)
        {
            double length1 = this.GetLongueurTotale();
            double length2 = pol.GetLongueurTotale();
            double precision;

            // précision = 1/100 de la plus grande valeur, totalement arbitraire
            if (length1 > length2) precision = length1 / 100;
            else precision = length2 / 100;

            if ( Math.Abs(length1 - length2) < precision  ) return true;
            else return false;
        }



        public int NbPoints()
        {
            int number = 0;
            for (int i = 0; i < Data.Count; i++)
            {
                number++;
                for (int j = 0; j < i; j++)
                {
                    if ((Data[i].Latitude == Data[j].Latitude) && (Data[i].Longitude == Data[j].Longitude)) number--;
                }

            }
            return Data.Count;
        }


        private void NotifyPropertyChanged([CallerMemberName] string propertyname = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
            }
        }



        //public void SaveObjet()
        //{
        //    BinaryFormatter binFormat = new BinaryFormatter();
        //    using (Stream fstream = new FileStream(@"Polyline" + Id + ".dat", FileMode.Append, FileAccess.Write, FileShare.None))
        //    {
        //        binFormat.Serialize(fstream, Data);
        //    }


        //}



        //public void LoadObjet(String s)
        //{
        //    BinaryFormatter binFormat = new BinaryFormatter();
        //    using (Stream fstream = new FileStream(s, FileMode.Open, FileAccess.Read, FileShare.None))
        //    {
        //        Polyline loaded = (Polyline)binFormat.Deserialize(fstream);
        //        this.Data = loaded.Data;
        //        this.Couleur = loaded.Couleur;
        //        this.Epaisseur = loaded.Epaisseur;
        //        this.Id = loaded.Id;
        //    }

        //}


    }
}
