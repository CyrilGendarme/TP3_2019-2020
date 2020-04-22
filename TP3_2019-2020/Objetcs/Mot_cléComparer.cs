using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP3_2019_2020.Objetcs
{
    class Mot_cléComparer : IEqualityComparer<Mot_clé>
    {
        private IComparer _baseComparer;

        public IComparer BaseComparer { get => _baseComparer; set => _baseComparer = value; }



        public bool Equals(Mot_clé x, Mot_clé y)
        {
            if (!((x.Nom).Equals(y.Nom))) return false;
            else return true;
        }

        public int GetHashCode(Mot_clé obj)   // à quoi cela sert-il ???
        {
            throw new NotImplementedException();
        }
    }
}
