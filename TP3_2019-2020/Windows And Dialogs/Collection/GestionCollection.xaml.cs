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
            MainGrid.Children.Add(ThisMenu);
            Grid.SetRow(ThisMenu, 0);
            MainGrid.DataContext = currentApp.MyData;
            UpdateStackPanel();
        }


        private void UpdateStackPanel()
        {
            var currentApp = System.Windows.Application.Current as App;

            int nbGroupe = currentApp.MyData.Colstruct.ListCollectionGroup.Count();

    
            foreach (TP3_2019_2020.Objetcs.CollectionGroup coll in currentApp.MyData.Colstruct.ListCollectionGroup)
            {
                StackPanel sp = new StackPanel();
                sp.Orientation = Orientation.Vertical;

                Label label = new Label();
                label.Content = coll.Nom;
                label.Width = 100;

                ListBox lb = new ListBox();
                //lb.ItemsSource = coll.ListeCollection;
                lb.DataContext = coll.ListeCollection;
                lb.HorizontalAlignment = HorizontalAlignment.Stretch;
                lb.VerticalAlignment = VerticalAlignment.Stretch;

                sp.Children.Add(label);
                sp.Children.Add(lb);

                //< ListBox x: Name = "ListBoxProduit" Grid.Column = "0" Height = "auto" Margin = "10,0,0,0" HorizontalAlignment = "Stretch"  VerticalAlignment = "Stretch" ItemsSource = "{Binding Path=ListProduit}" >
                //     </ ListBox >
                StackPanelCollections.Children.Add(sp);
            }

        }



        private void Ajouter_collection_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Supprimer_colletion_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Ajouter_groupe_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Supprimer_groupe_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
