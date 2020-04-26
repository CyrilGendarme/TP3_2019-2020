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
    /// Interaction logic for AjoutProduit.xaml
    /// </summary>
    public partial class AjoutProduit : Window
    {
        private GestionProduits _owner;
        public Objetcs.Produit ThisProd;

        public AjoutProduit()
        {
            _owner = Owner as GestionProduits;
            InitializeComponent();
            ThisProd = new Objetcs.Produit();
        }

        public AjoutProduit(TP3_2019_2020.Objetcs.Produit p)
        {
            _owner = Owner as GestionProduits;
            InitializeComponent();
            ThisProd = p;
        }

        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            ThisProd.ListeCollections = ((List<TP3_2019_2020.Objetcs.Collection>)ListBoxCollection1.SelectedItem);
            _owner.AddToProduitList(ThisProd);
            this.Hide();
        }

        private void Suivant_Click(object sender, RoutedEventArgs e)
        {
            ThisProd.ListeCollections = ((List<TP3_2019_2020.Objetcs.Collection>)ListBoxCollection1.SelectedItem);
            _owner.AddToProduitList(ThisProd);
            ThisProd = new Objetcs.Produit();
            ListBoxCollection1.UnselectAll();
        }

        private void Annuler_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }

        private void ConfigMot_Click(object sender, RoutedEventArgs e)
        {
            GestionMotCleProduit win = new GestionMotCleProduit();
            win.Show();
        }

    }
}
