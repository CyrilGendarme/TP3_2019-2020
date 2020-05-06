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
        List<ListBox> ListLB;
        public Objetcs.Produit ThisProd;

        public AjoutProduit()
        {
            InitializeComponent();
            var currentApp = System.Windows.Application.Current as App;
            Menu ThisMenu = currentApp.MyMenu;
            Grid parentGrid = ThisMenu.Parent as Grid;
            if(parentGrid != null) {
                parentGrid.Children.Remove(ThisMenu);
            }
            MainGrid.Children.Add(ThisMenu);
            Grid.SetRow(ThisMenu, 0);
            ListLB = new List<ListBox>();
            ThisProd = new Objetcs.Produit();
            UpdateStackPanel();
        }


        public AjoutProduit(TP3_2019_2020.Objetcs.Produit p)
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
            ListLB = new List<ListBox>();
            ThisProd = p;
            UpdateStackPanel();
        }



        public void PutMotClé(Mot_clé mot)
        {
            ThisProd.Mot_clé = mot;
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
                label.Height = 20;

                ListBox lb = new ListBox();
                //lb.ItemsSource = coll.ListeCollection;
                lb.DataContext = coll.ListeCollection;
                lb.HorizontalAlignment = HorizontalAlignment.Stretch;
                lb.VerticalAlignment = VerticalAlignment.Stretch;

                ListLB.Add(lb);
                sp.Children.Add(label);
                sp.Children.Add(lb);

                //< ListBox x: Name = "ListBoxProduit" Grid.Column = "0" Height = "auto" Margin = "10,0,0,0" HorizontalAlignment = "Stretch"  VerticalAlignment = "Stretch" ItemsSource = "{Binding Path=ListProduit}" >
                //     </ ListBox >
                StackPanelCollections.Children.Add(sp);
            }
        }





           
        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            var currentApp = System.Windows.Application.Current as App;
            foreach (ListBox listbox in ListLB)
            {
                if (listbox.SelectedIndex != -1 )
                {
                    ThisProd.ListeCollections.Add((TP3_2019_2020.Objetcs.Collection)listbox.SelectedItems);
                    listbox.UnselectAll();
                }
            }

            currentApp.MyData.ListProduit.Add(ThisProd);
            this.Hide();
        }

        private void Suivant_Click(object sender, RoutedEventArgs e)
        {
            var currentApp = System.Windows.Application.Current as App;
            foreach (ListBox listbox in ListLB)
            {
                if (listbox.SelectedIndex != -1)
                {
                    ThisProd.ListeCollections.Add((TP3_2019_2020.Objetcs.Collection)listbox.SelectedItems);
                    listbox.UnselectAll();
                }
            }
            currentApp.MyData.ListProduit.Add(ThisProd);
        }

        private void Annuler_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }

        private void ConfigMot_Click(object sender, RoutedEventArgs e)
        {
            AjoutMotCle win = new AjoutMotCle(this);
            win.ShowDialog();
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
