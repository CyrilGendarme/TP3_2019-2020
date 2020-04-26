using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP3_2019_2020.Objetcs
{
    class ProduitComparatorByDate : Comparer<Produit>
    {
        public override int Compare(Produit x, Produit y)
        {
            return DateTime.Compare(x.DateCreation, y.DateCreation);
        }
    }
}
