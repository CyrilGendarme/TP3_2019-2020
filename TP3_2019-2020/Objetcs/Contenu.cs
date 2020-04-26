using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TP3_2019_2020.Objetcs
{
    public class Contenu : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public String Nom { get; set; }
        public DateTime DateCreation { get; set; }
        public int Id { get; }
        protected static int counter = 0;


        public void SetMaxCnt(int nb)
        {
            counter = nb;
        }


        public Contenu()
        {
            counter++;
            Id = counter;
            Nom = "NULL";
            DateCreation = DateTime.Now.Date;
        }

        public Contenu(String nom)
        {
            counter++;
            Id = counter;
            Nom = nom;
            DateCreation = DateTime.Now.Date;
        }


        private void NotifyPropertyChanged([CallerMemberName] string propertyname = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
            }
        }

        public override String ToString()
        {
            return Nom;
        }

    }

}

