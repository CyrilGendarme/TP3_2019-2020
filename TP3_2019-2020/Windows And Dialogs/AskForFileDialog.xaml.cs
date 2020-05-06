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


        public AskForFileDialog()
        {
            var currentApp = System.Windows.Application.Current as App;
            DataContext = currentApp.MyData;
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
                var currentApp = System.Windows.Application.Current as App;
                DataContext = currentApp.MyData.FilePath = "D:\\Visual Studio 2k19\\TP3_2019-2020\\DATA\\" + NouveauSite.Text;
            }
            else
            {
                var currentApp = System.Windows.Application.Current as App;
                String path = "D:\\Visual Studio 2k19\\TP3_2019-2020\\DATA\\" + ListBoxSites.SelectedItem.ToString();
                currentApp.MyData.FilePath = path;
                currentApp.MyData.LoadData(path);
            }
            this.Hide();
            MainWindow win = new MainWindow();
            win.Show();
        }

        private void FournisseurBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            ListBoxSites.UnselectAll();
        }
    }
}
