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
    /// Interaction logic for GestionProduits.xaml
    /// </summary>
    public partial class GestionProduits : Window
    {
        public GestionProduits()
        {
            InitializeComponent();
        }

        private void Ajout_Click(object sender, RoutedEventArgs e)
        {
            AjoutProduit win = new AjoutProduit();
            win.Show();
        }




        private void CheckBox_Checked1(object sender, RoutedEventArgs e)
        {
            BoxParCollection.IsChecked = false;
            BoxParDate.IsChecked = false;
        }

        private void CheckBox_Checked2(object sender, RoutedEventArgs e)
        {
            BoxParNom.IsChecked = false;
            BoxParDate.IsChecked = false;
        }

        private void CheckBox_Checked3(object sender, RoutedEventArgs e)
        {
            BoxParNom.IsChecked = false;
            BoxParCollection.IsChecked = false;
        }


    }
}
