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




        private void Application_Startup(object sender, StartupEventArgs e)
        {

            // création du menu
            MyMenu = new Menu();

            MyMenu.Height = 30;

            MenuItem menuItem1 = new MenuItem();
            MenuItem menuItem2 = new MenuItem();
            MenuItem menuItem3 = new MenuItem();
            MenuItem menuItem4 = new MenuItem();

            menuItem1.Header = "Accueil";
            menuItem2.Header = "Options";
            menuItem3.Header = "Sauvegarder";
            menuItem4.Header = "Changer de site";

            menuItem1.Click += MenuItem_Click;
            menuItem2.Click += MenuItem_Click_1;
            menuItem3.Click += MenuItem_Click_2;
            menuItem4.Click += MenuItem_Click_3;

            menuItem1.Height = 30;
            menuItem2.Height = 30;
            menuItem3.Height = 30;
            menuItem4.Height = 30;

            menuItem1.Width = 100;
            menuItem2.Width = 100;
            menuItem3.Width = 100;
            menuItem4.Width = 200;

            MyMenu.Items.Add(menuItem1);
            MyMenu.Items.Add(menuItem2);
            MyMenu.Items.Add(menuItem3);
            MyMenu.Items.Add(menuItem4);

            // création de l'objet MyData
            MyData = new MyData();

            // lancement de la premiere win 
            MainWindow win = new MainWindow();
            win.Show();
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
