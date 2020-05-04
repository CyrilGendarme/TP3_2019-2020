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
using System.IO;


namespace TP3_2019_2020.Windows_And_Dialogs
{
    /// <summary>
    /// Interaction logic for AskForFileDialog.xaml
    /// </summary>
    public partial class AskForFileDialog : Window
    {

        public MainWindow _owner { get; set; }


        public AskForFileDialog(MainWindow Owner)
        {
            _owner = Owner;
            DataContext = _owner.MyData;
            InitializeComponent();


            String[] files = System.IO.Directory.GetFiles("D:\\Visual Studio 2k19\\TP3_2019-2020\\DATA");   // 
            for (int i = 0; i < files.Length; i++) 
            {
                String sitename = System.IO.Path.GetFileName(files[i]);
                ListBoxSites.Items.Add(files[i]);
            }



        }

        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            if (ListBoxSites.SelectedIndex == -1)
            {
                _owner.MyData.FilePath = "D:\\Visual Studio 2k19\\TP3_2019-2020\\DATA\\" + NouveauSite.Text;
            }
            else
            {
                String path = "D:\\Visual Studio 2k19\\TP3_2019-2020\\DATA\\" + ListBoxSites.SelectedItem.ToString();
                _owner.MyData.FilePath = path;
                _owner.MyData.LoadData(path);
            }
            this.Hide();
        }

        private void FournisseurBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            ListBoxSites.UnselectAll();
        }
    }
}
