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
        List<ComboBox> ListCB;
        public Objetcs.Produit ThisProd;

        public AjoutProduit()
        {
            ListLB = new List<ListBox>();
            ListCB = new List<ComboBox>();
            ThisProd = new Objetcs.Produit();
            InitializeComponent();
            UpdateStackPanel();
            MainGrid.DataContext = ThisProd;
        }


        public AjoutProduit(TP3_2019_2020.Objetcs.Produit p)
        {
            ListLB = new List<ListBox>();
            ListCB = new List<ComboBox>();
            ThisProd = p;
            InitializeComponent();
            UpdateStackPanel();
            MainGrid.DataContext = ThisProd;
        }



        public void PutMotClé(Mot_clé mot)
        {
            ThisProd.Mot_clé = mot;
            ThisProd.Nom = mot.Nom;
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
                label.Height = 30;

                ListBox lb = new ListBox();
                ComboBox cb = new ComboBox();
                //lb.ItemsSource = coll.ListeCollection;
                lb.DataContext = coll;
                lb.ItemsSource = coll.ListeCollection;
                cb.DataContext = coll;
                cb.ItemsSource = coll.ListeCollection;
                lb.HorizontalAlignment = HorizontalAlignment.Stretch;
                lb.VerticalAlignment = VerticalAlignment.Stretch;
                lb.SelectionMode = SelectionMode.Multiple;

                ListLB.Add(lb);
                ListCB.Add(cb);
                sp.Children.Add(label);
                sp.Children.Add(cb);

                //< ListBox x: Name = "ListBoxProduit" Grid.Column = "0" Height = "auto" Margin = "10,0,0,0" HorizontalAlignment = "Stretch"  VerticalAlignment = "Stretch" ItemsSource = "{Binding Path=ListProduit}" >
                //     </ ListBox >
                StackPanelCollections.Children.Add(sp);
            }
        }





           
        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            var currentApp = System.Windows.Application.Current as App;

            try
            {
                foreach (ListBox listbox in ListLB)
                {
                    if (listbox.SelectedIndex != -1)
                    {
                        ThisProd.ListeCollections.Add((TP3_2019_2020.Objetcs.Collection)listbox.SelectedItems);
                        listbox.UnselectAll();
                    }
                }

                currentApp.MyData.ListProduit.Add(ThisProd);
                this.Hide();
            }
            catch { var result = System.Windows.Forms.MessageBox.Show("Mauvaises données rentrées", "Fermer", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Exclamation);}
        }

        private void Suivant_Click(object sender, RoutedEventArgs e)
        {
            var currentApp = System.Windows.Application.Current as App;

            try
            {
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
            catch { var result = System.Windows.Forms.MessageBox.Show("Mauvaises données rentrées", "Fermer", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Exclamation); }
        
        }

        private void Annuler_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }

        private void ConfigMot_Click(object sender, RoutedEventArgs e)
        {
            CreateContent.IsEnabled = true;
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

        private void CreateContent_Click(object sender, RoutedEventArgs e)
        {
            //foreach (ListBox listbox in ListLB)
            //{
            //    if (listbox.SelectedIndex != -1)
            //    {
            //        List<Objetcs.Collection> listlb = listbox.SelectedItems as List<Objetcs.Collection>;
            //        foreach (Objetcs.Collection coll in listlb)
            //        {
            //            ThisProd.ListeCollections.Add(coll);
            //        }
            //    }
            //}
            AskDataForDescription win = new AskDataForDescription(ThisProd);
            win.ShowDialog();
        }
    }
}
