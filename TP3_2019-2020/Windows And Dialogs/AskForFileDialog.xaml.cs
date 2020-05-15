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
using Microsoft.Win32;

namespace TP3_2019_2020.Windows_And_Dialogs
{
    /// <summary>
    /// Interaction logic for AskForFileDialog.xaml
    /// </summary>
    public partial class AskForFileDialog : Window
    {

        public MainWindow _owner { get; set; }
        private RegistryKey rk;

        public AskForFileDialog()
        {
            var currentApp = System.Windows.Application.Current as App;
            DataContext = currentApp.MyData;
            InitializeComponent();

            rk = Registry.CurrentUser.OpenSubKey("TP3Folder");


            String[] files = System.IO.Directory.GetFiles(rk.GetValue("Path").ToString());   // 
            for (int i = 0; i < files.Length; i++) 
            {
                String sitename = System.IO.Path.GetFileName(files[i])/*.Remove(0,40)*/;
                ListBoxSites.Items.Add(sitename);
            }


            //DataTemplate dt = new DataTemplate();
            //dt.DataType

            //ListBoxSites.ItemTemplate = (DataTemplate)this.
        }



        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            if (ListBoxSites.SelectedIndex == -1)
            {
                var currentApp = System.Windows.Application.Current as App;
                currentApp.MyData = new MyData();
                DataContext = currentApp.MyData.FilePath = rk.GetValue("Path").ToString() + NouveauSite.Text;
            }
            else
            {
                var currentApp = System.Windows.Application.Current as App;
                String path = rk.GetValue("Path").ToString() +"\\"+ ListBoxSites.SelectedItem.ToString();
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
