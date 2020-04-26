using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP3_2019_2020.Objetcs
{
    class ProduitComparatorByName : Comparer<Produit>
    {
        public override int Compare(Produit x, Produit y)
    {
        return String.Compare(x.Nom, y.Nom);
    }
}
}
