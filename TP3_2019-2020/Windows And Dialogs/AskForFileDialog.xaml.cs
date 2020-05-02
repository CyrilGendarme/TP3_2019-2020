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

namespace TP3_2019_2020.Windows_And_Dialogs
{
    /// <summary>
    /// Interaction logic for AskForFileDialog.xaml
    /// </summary>
    public partial class AskForFileDialog : Window
    {

        private MainWindow _owner;


        public AskForFileDialog()
        {
            _owner = Owner as MainWindow;
            DataContext = _owner.MyData;
            InitializeComponent();
        }

        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            if (ListBoxSites.SelectedIndex == -1)
            {
                _owner.MyData.FilePath = NouveauSite.Text;
            }
            else
            {
                String path = ListBoxSites.SelectedItem.ToString();
                _owner.MyData.LoadData(path);
            }
        }

        private void FournisseurBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            ListBoxSites.UnselectAll();
        }
    }
}
