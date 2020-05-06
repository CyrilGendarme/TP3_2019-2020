﻿using System;
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
    /// Interaction logic for AjoutGroupe.xaml
    /// </summary>
    public partial class AjoutGroupe : Window
    {
        CollectionGroup ThisGroup;
        public AjoutGroupe()
        {
            InitializeComponent();
            ThisGroup = new CollectionGroup();
            DataContext = ThisGroup;
            var currentApp = System.Windows.Application.Current as App;
            Menu ThisMenu = currentApp.MyMenu;
            Grid parentGrid = ThisMenu.Parent as Grid;
            if (parentGrid != null)
            {
                parentGrid.Children.Remove(ThisMenu);
            }
            MainGrid.Children.Add(ThisMenu);
            Grid.SetRow(ThisMenu, 0);

        }

        private void CreateContent_Click(object sender, RoutedEventArgs e)
        {
            var currentApp = System.Windows.Application.Current as App;
            currentApp.MyData.Colstruct.ListCollectionGroup.Add(ThisGroup);
            this.Hide();
        }

        private void Annuler_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }

        private void ConfigMot_Click(object sender, RoutedEventArgs e)
        {
            AjoutMotCle win = new AjoutMotCle(this);
            win.ShowDialog();
        }

        private void CreateContentAndNext_Click(object sender, RoutedEventArgs e)
        {
            var currentApp = System.Windows.Application.Current as App;
            currentApp.MyData.Colstruct.ListCollectionGroup.Add(ThisGroup);
            ThisGroup = new CollectionGroup();
        }
    }
}
