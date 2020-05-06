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
using TP3_2019_2020.Objetcs;

namespace TP3_2019_2020.Windows_And_Dialogs.Produit
{
    /// <summary>
    /// Interaction logic for AjoutProduit.xaml
    /// </summary>
    public partial class AjoutProduit : Window
    {

        public Objetcs.Produit ThisProd;

        public AjoutProduit()
        {
            var currentApp = System.Windows.Application.Current as App;
            Menu ThisMenu = currentApp.MyMenu;
            MainGrid.Children.Add(ThisMenu);
            Grid.SetRow(ThisMenu, 0);
            ListBoxCollection1.DataContext = currentApp.MyData.ListCollection;
            InitializeComponent();
            ThisProd = new Objetcs.Produit();
        }

        public AjoutProduit(TP3_2019_2020.Objetcs.Produit p)
        {
            var currentApp = System.Windows.Application.Current as App;
            ListBoxCollection1.DataContext = currentApp.MyData.ListCollection;
            InitializeComponent();
            ThisProd = p;
        }






        public void PutMotClé(Mot_clé mot)
        {
            ThisProd.Mot_clé = mot;
        }





        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            ThisProd.ListeCollections = ((List<TP3_2019_2020.Objetcs.Collection>)ListBoxCollection1.SelectedItem);
            var currentApp = System.Windows.Application.Current as App;
            currentApp.MyData.ListProduit.Add(ThisProd);
            this.Hide();
        }

        private void Suivant_Click(object sender, RoutedEventArgs e)
        {
            ThisProd.ListeCollections = ((List<TP3_2019_2020.Objetcs.Collection>)ListBoxCollection1.SelectedItem);
            var currentApp = System.Windows.Application.Current as App;
            currentApp.MyData.ListProduit.Add(ThisProd);
            ThisProd = new Objetcs.Produit();
            ListBoxCollection1.UnselectAll();
        }

        private void Annuler_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }

        private void ConfigMot_Click(object sender, RoutedEventArgs e)
        {
            AjoutMotCle win = new AjoutMotCle(this);
            win.Show();
        }

        private void AchatBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try 
            {
                double prixachat = Convert.ToDouble(AchatBox.Text);
                double prixvente = prixachat * 3.2;
                if (prixvente < 4.70) prixvente = 4.70;
                if ((prixvente - prixachat) > 20) prixvente = prixachat + 20;
                ThisProd.PrixVente = prixvente;
            }
            catch { }
        }
    }
}
