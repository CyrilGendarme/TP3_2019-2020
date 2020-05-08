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
    /// Interaction logic for VoirListePhrases.xaml
    /// </summary>
    public partial class VoirListePhrases : Window
    {
        public VoirListePhrases()
        {
            InitializeComponent();
            var currentApp = System.Windows.Application.Current as App;
            ListBoxPhrases.DataContext = currentApp.MyData;
        }

        private void Supprimer_Click(object sender, RoutedEventArgs e)
        {
            var currentApp = System.Windows.Application.Current as App;
            currentApp.MyData.ListPhrases.Remove((String)ListBoxPhrases.SelectedItem);
        }

        private void Ajout_Click(object sender, RoutedEventArgs e)
        {
            var currentApp = System.Windows.Application.Current as App;
            currentApp.MyData.ListPhrases.Add(MyTextBox.Text);
        }
    }
}
