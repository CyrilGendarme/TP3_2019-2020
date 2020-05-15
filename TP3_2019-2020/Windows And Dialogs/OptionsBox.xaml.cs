using Microsoft.Win32;
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

namespace TP3_2019_2020.Windows_And_Dialogs
{
    /// <summary>
    /// Interaction logic for OptionsBox.xaml
    /// </summary>
    public partial class OptionsBox : Window
    {
        private RegistryKey rk;

        public OptionsBox()
        {
            InitializeComponent();

            rk = Registry.CurrentUser.OpenSubKey("TP3Folder", RegistryKeyPermissionCheck.ReadWriteSubTree);

            DataContext = rk;
            text.Text = rk.GetValue("Path").ToString();
        }

        private void Modifier_Click(object sender, RoutedEventArgs e)
        {
            rk.SetValue("Path", text.Text);
            this.Hide();
        }
    }
}
