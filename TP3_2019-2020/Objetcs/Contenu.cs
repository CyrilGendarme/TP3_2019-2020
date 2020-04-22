using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP3_2019_2020.Objetcs
{
    public class Contenu
    {
        public String Nom { get; set; }
        public DateTime DateCreation { get; set; }



        public Contenu()
        {
            Nom = "NULL";
            DateCreation = DateTime.Now.Date;
        }

        public Contenu(String nom)
        {
            Nom = nom;
            DateCreation = DateTime.Now.Date;
        }


    }
}
