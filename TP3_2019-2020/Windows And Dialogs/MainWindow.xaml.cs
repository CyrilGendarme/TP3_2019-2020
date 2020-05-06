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
using System.Windows.Navigation;
using System.Windows.Shapes;
using TP3_2019_2020.Windows_And_Dialogs.Produit;
//using TP3_2019_2020.Windows_And_Dialogs.Article;
//using TP3_2019_2020.Windows_And_Dialogs.Collection;
//using TP3_2019_2020.Windows_And_Dialogs.Thématique;
using TP3_2019_2020.Objetcs;
using TP3_2019_2020.Windows_And_Dialogs;

namespace TP3_2019_2020
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {


        public MainWindow()
        {
            InitializeComponent();
        }

        private void Produit_Click(object sender, RoutedEventArgs e)
        {
            GestionProduits win = new GestionProduits();
            win.Show();
            this.Hide();
        }

        private void Collection_Click(object sender, RoutedEventArgs e)
        {
            //GestionCollection win = new GestionCollection();
            //win.Show();
            //this.Hide();
        }

        private void Thématique_Click(object sender, RoutedEventArgs e)
        {
            //GestionThématique win = new GestionThématique);
            //win.Show();
            //this.Hide();
        }

        private void Article_Click(object sender, RoutedEventArgs e)
        {
            //GestionArticle win = new GestionArticle();
            //win.Show();
            //this.Hide();
        }
    }
}
