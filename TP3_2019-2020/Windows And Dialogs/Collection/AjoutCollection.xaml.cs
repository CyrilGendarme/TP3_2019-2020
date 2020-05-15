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
    /// Interaction logic for AjoutCollection.xaml
    /// </summary>
    public partial class AjoutCollection : Window
    {
        public TP3_2019_2020.Objetcs.Collection ThisCollection { get; set; }


        public AjoutCollection()
        {

            ThisCollection = new Objetcs.Collection();
            InitializeComponent();
            DataContext = ThisCollection;
            var currentApp = System.Windows.Application.Current as App;
            ListGroupes.DataContext = currentApp.MyData.Colstruct;
            labelnom.DataContext = ThisCollection;
        }

        public AjoutCollection(Objetcs.Collection coll)
        {

            ThisCollection = coll;
            InitializeComponent();
            DataContext = ThisCollection;
            var currentApp = System.Windows.Application.Current as App;
            ListGroupes.DataContext = currentApp.MyData.Colstruct;
            labelnom.DataContext = ThisCollection;
        }

        private void Annuler_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }

        private void CreateContent_Click(object sender, RoutedEventArgs e)
        {
            var currentApp = System.Windows.Application.Current as App;

            try
            {
                currentApp.MyData.ListCollection.Add(ThisCollection);
                CollectionGroup group = ListGroupes.SelectedItem as CollectionGroup;
                group.ListeCollection.Add(ThisCollection);
                this.Hide();
            }
            catch { var result = System.Windows.Forms.MessageBox.Show("Mauvaises données rentrées", "Fermer", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Exclamation); }
        }

        private void CreateContentAndNext_Click(object sender, RoutedEventArgs e)
        {
            var currentApp = System.Windows.Application.Current as App;
            try
            {
                currentApp.MyData.ListCollection.Add(ThisCollection);
                CollectionGroup group = ListGroupes.SelectedItem as CollectionGroup;
                group.ListeCollection.Add(ThisCollection);
                ThisCollection = new Objetcs.Collection();
            }
            catch { var result = System.Windows.Forms.MessageBox.Show("Mauvaises données rentrées", "Fermer", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Exclamation); }
        }

        private void ConfigMot_Click(object sender, RoutedEventArgs e)
        {
            AjoutMotCle win = new AjoutMotCle(this);
            win.ShowDialog();
        }
    }
}
