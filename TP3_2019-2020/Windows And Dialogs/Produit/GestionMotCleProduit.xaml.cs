using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace TP3_2019_2020.Windows_And_Dialogs.Produit
{
    /// <summary>
    /// Interaction logic for GestionMotCleProduit.xaml
    /// </summary>
    public partial class GestionMotCleProduit : Window
    {
        private AjoutProduit _owner;

        public GestionMotCleProduit()
        {
            _owner = Owner as AjoutProduit;
            InitializeComponent();
            DataContext = _owner.ThisProd.Mot_clé;
        }
    }
}
