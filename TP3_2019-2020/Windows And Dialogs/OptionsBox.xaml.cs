using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
        public delegate void UpdateHandler(System.Windows.Media.Brush col1, System.Windows.Media.Brush col2);
        public event UpdateHandler MenuColorUpdate;

        public OptionsBox()
        {
            InitializeComponent();

            CouleurFond.ItemsSource = typeof(Colors).GetProperties();
            CouleurTexte.ItemsSource = typeof(Colors).GetProperties();

            rk = Registry.CurrentUser.OpenSubKey("TP3Folder", RegistryKeyPermissionCheck.ReadWriteSubTree);

            DataContext = rk;
            text.Text = rk.GetValue("Path").ToString();
        }

        private void ModifierP_Click(object sender, RoutedEventArgs e)
        {
            rk.SetValue("Path", text.Text);
            this.Hide();
        }

        private void ModifierC_Click(object sender, RoutedEventArgs e)
        {
            UpdateMethod();
            this.Hide();
        }


        private void UpdateMethod()
        {
            if (MenuColorUpdate != null)
            {
                Object brush1;
                Object brush2;

                if (CouleurTexte.SelectedItem != null)
                {
                    PropertyInfo selectedItem1 = (PropertyInfo)CouleurTexte.SelectedItem;
                    var color1 = (Color)selectedItem1.GetValue(null, null);
                    var converter1 = new System.Windows.Media.BrushConverter();
                    brush1 = (Brush)converter1.ConvertFromString(color1.ToString());
                }
                else
                {
                    var converter1 = new System.Windows.Media.BrushConverter();
                    brush1 = (Brush)converter1.ConvertFromString(System.Windows.Media.Colors.Black.ToString());
                }

                if (CouleurTexte.SelectedItem != null)
                {
                    PropertyInfo selectedItem2 = (PropertyInfo)CouleurFond.SelectedItem;
                    var color2 = (Color)selectedItem2.GetValue(null, null);
                    var converter2 = new System.Windows.Media.BrushConverter();
                    brush2 = (Brush)converter2.ConvertFromString(color2.ToString());
                }
                else
                {
                    var converter2 = new System.Windows.Media.BrushConverter();
                    brush2 = (Brush)converter2.ConvertFromString(System.Windows.Media.Colors.White.ToString());
                }


                MenuColorUpdate((Brush)brush1, (Brush)brush2);
            }
        }
    }
}
