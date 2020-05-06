using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for GestionProduits.xaml
    /// </summary>
    public partial class GestionProduits : Window
    {


        public GestionProduits()
        {
            InitializeComponent();
            var currentApp = System.Windows.Application.Current as App;
            Menu ThisMenu = currentApp.MyMenu;
            Grid parentGrid = ThisMenu.Parent as Grid;
            if (parentGrid != null)
            {
                parentGrid.Children.Remove(ThisMenu);
            }
            MainGrid.Children.Add(ThisMenu);
            Grid.SetRow(ThisMenu, 0);
            MainGrid.DataContext = currentApp.MyData;
            //var currentApp2 = App.Current as App;
            //ThisMenu = currentApp2.MyMenu;
            //MainGrid.DataContext = currentApp2.MyData;
            ListBoxDonnéesProduit.DataContext = ListBoxProduit;
        }






        private void Ajout_Click(object sender, RoutedEventArgs e)
        {
            AjoutProduit win = new AjoutProduit();
            win.ShowDialog();
        }




        private void CheckBox_Checked1(object sender, RoutedEventArgs e)
        {
            BoxParDate.IsChecked = false;
            var currentApp = System.Windows.Application.Current as App;
            ListBoxProduit.DataContext = currentApp.MyData.ListArticle.OrderBy(d => d.DateCreation);
        }


        private void CheckBox_Checked3(object sender, RoutedEventArgs e)
        {
            BoxParNom.IsChecked = false;
            var currentApp = System.Windows.Application.Current as App;
            ListBoxProduit.DataContext = currentApp.MyData.ListArticle.OrderBy(d => d.Nom);
        }


        private void Supprimer_Click(object sender, RoutedEventArgs e)
        {
            var currentApp = System.Windows.Application.Current as App;
            currentApp.MyData.ListProduit.Remove((TP3_2019_2020.Objetcs.Produit)ListBoxProduit.SelectedItem);
        }

        private void Modifier_Click(object sender, RoutedEventArgs e)
        {
            AjoutProduit win = new AjoutProduit((TP3_2019_2020.Objetcs.Produit)ListBoxProduit.SelectedItem);
            win.ShowDialog();
        }


    }
}
