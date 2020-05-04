using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using TP3_2019_2020.Objetcs;
using TP3_2019_2020.Windows_And_Dialogs;

namespace TP3_2019_2020
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public Menu MyMenu { get; set; }

        private MyData _myData;
        public MyData MyData
        {
            get => _myData;
            set
            {
                _myData = value;

            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
            MainWindow win = new MainWindow();
            win.Show();
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
            //OptionBox win = new OptionBox();
            //win.Show();
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            MyData.SaveData();
        }

        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
            AskForFileDialog win = new AskForFileDialog();
            win.Show();
        }
    }
}
