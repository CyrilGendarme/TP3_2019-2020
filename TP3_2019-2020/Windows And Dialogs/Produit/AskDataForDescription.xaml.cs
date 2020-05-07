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
    /// Interaction logic for AskDataForDescription.xaml
    /// </summary>
    public partial class AskDataForDescription : Window
    {

        Objetcs.Produit produit;

        public AskDataForDescription(Objetcs.Produit prod)
        {
            produit = prod;
            InitializeComponent();
        }

        private void Générér_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Voir_liste_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Ajouter_phrase_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
