using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP3_2019_2020.Objetcs
{
    public class Mot_clé
    {
        public String Nom { get; set; }
        public int Volume { get; set; }

        private double _difficulté; // valeur comprise entre 0 et 100
        public double Difficulté
        {
            get => _difficulté;
            set
            {
                if (value <= 100 && value >= 0) _difficulté = value;
                else
                {
                    DialogResult result;
                    result = MessageBox.Show("La difficulté doit être comprise entre 0 et 100", "Erreur de valeur", MessageBoxButtons.OK);
                }
            }
        }


        public Mot_clé()
        {
            Nom = "NULL";
            Volume = 0;
            Difficulté = 100;
        }

        public Mot_clé(String s, int v, double d)
        {
            Nom = s;
            Volume = v;
            Difficulté = d;
        }

        public override String ToString()
        {
            return Nom;
        }
    }
}
