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

namespace TP3_2019_2020.Windows_And_Dialogs.Collection
{
    /// <summary>
    /// Interaction logic for GestionCollection.xaml
    /// </summary>
    public partial class GestionCollection : Window
    {
        public GestionCollection()
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
        }





        private void Ajouter_collection_Click(object sender, RoutedEventArgs e)
        {
            AjoutCollection win = new AjoutCollection();
            win.ShowDialog();
        }

        private void Supprimer_colletion_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Ajouter_groupe_Click(object sender, RoutedEventArgs e)
        {
            AjoutGroupe win = new AjoutGroupe();
            win.ShowDialog();
        }

        private void Supprimer_groupe_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Modifier_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
