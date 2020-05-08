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
    /// Interaction logic for AskDataForDescription.xaml
    /// </summary>
    public partial class AskDataForDescription : Window
    {
        String text;

        Objetcs.Produit produit;

        public AskDataForDescription(Objetcs.Produit prod)
        {
            produit = prod;
            InitializeComponent();
        }

        private void Générér_Click(object sender, RoutedEventArgs e)
        {
            text = "";
            text = text + "<h2>" + PhraseIntro.Text + "</h2>\n<ul>\n";

            if (! (MatériauBox1.Text.Equals("")) ) text = text + "<strong>Matériau</strong>" + " : " + MatériauBox1.Text + "\n";
            if (! (TailleCommentaireBox.Text.Equals("")) ) text = text + "<strong>" + TailleValeurBox.Text + "</strong>" + " : " + TailleCommentaireBox.Text + "\n";
            if (! (TailleCommentaireBox2.Text.Equals("")) ) text = text + "<strong>" + TailleValeurBox2.Text + "</strong>" + " : " + TailleCommentaireBox2.Text + "\n";
            if (! (PoidsBox.Text.Equals(""))) text = text + "Poids : " + PoidsBox.Text + "\n";
            if (! (BoxSupp1a.Text.Equals(""))) text = text + "<strong>" + BoxSupp1a.Text + "</strong>" + " : " + BoxSupp1b.Text + "\n";
            if (! (BoxSupp2a.Text.Equals(""))) text = text + "<strong>" + BoxSupp2a.Text + "</strong>" + " : " + BoxSupp2b.Text + "\n";
            if (! (BoxSupp3a.Text.Equals(""))) text = text + "<strong>" + BoxSupp3a.Text + "</strong>" + " : " + BoxSupp3b.Text + "\n";

            var currentApp = System.Windows.Application.Current as App;
            foreach(String s in currentApp.MyData.ListPhrases)
            {
                if (s.Contains("LIVRAISON") || s.Contains("Livraison") || s.Contains("livraison")) text = text + "<strong>" + s + "</strong>\n";  
                else  text = text + s + "\n";
            }
            text = text + "\n</ul>\nLes tailles de tous nos produits correspondent aux normes françaises en vigueur.\n";

            TextResult.Text = text;
        }

        private void Voir_liste_Click(object sender, RoutedEventArgs e)
        {
            VoirListePhrases win = new VoirListePhrases();
            win.ShowDialog();
        }


    }
}
