using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TP3_2019_2020.Objetcs;
using TP3_2019_2020.Windows_And_Dialogs.Collection;
using TP3_2019_2020.Windows_And_Dialogs.Produit;

namespace TP3_2019_2020.Windows_And_Dialogs
{
    /// <summary>
    /// Interaction logic for GestionMotCleProduit.xaml
    /// </summary>
    public partial class AjoutMotCle : Window
    {


        private AjoutProduit _owner;
        private AjoutCollection _owner2;
        private AjoutGroupe _owner3;
        //private AjoutArticle _owner3;
        int cas = 0;   // valeur differente pour chaque type de appli appelante

        public AjoutMotCle(Window Owner)
        {
            // if is pour voir dans quel cas on est pour gerer plusieurs appli demandant la gestion de motclé
            if (Owner is AjoutProduit) { _owner = Owner as AjoutProduit; cas = 1; }
            if (Owner is AjoutCollection) { _owner2 = Owner as AjoutCollection; cas = 2; }
            if (Owner is AjoutGroupe) { _owner3 = Owner as AjoutGroupe; cas = 3; }
            InitializeComponent();
        }

        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            Mot_clé mot = new Mot_clé();
            Boolean test = true;
            var currentApp = System.Windows.Application.Current as App;

            foreach (Mot_clé word in currentApp.MyData.ListMotClé)
            {
                if (word.Nom.Equals(Nom.Text)) { test = false; mot = word; var result = System.Windows.Forms.MessageBox.Show("Ce mot-clé existe déjà et a été chargé", "Fermer",  MessageBoxButtons.OK,  MessageBoxIcon.Exclamation); break; }
            }
            if (test == true)
            {
                mot = new Mot_clé(Nom.Text, Convert.ToInt32(Volume.Text), Difficulté.Value);
                currentApp.MyData.ListMotClé.Add(mot);
            }


            if (cas == 1) _owner.PutMotClé(mot);
            if (cas == 2) {
                _owner2.ThisCollection.Mot_clé = mot; 
                _owner2.ThisCollection.Nom = mot.Nom; }
            if (cas == 3) {
                _owner3.ThisGroup.Mot_clé = mot;
                _owner3.ThisGroup.Nom = mot.Nom; }

            this.Hide();
        }
    }
}
