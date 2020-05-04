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
        private GestionProduits _owner;
        public Objetcs.Produit ThisProd;

        public AjoutProduit(GestionProduits Owner)
        {
            _owner = Owner;
            InitializeComponent();
            ThisProd = new Objetcs.Produit();
        }

        public AjoutProduit(GestionProduits Owner, TP3_2019_2020.Objetcs.Produit p)
        {
            _owner = Owner;
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
            AjoutMotCle win = new AjoutMotCle(this, _owner.DataContext);
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
