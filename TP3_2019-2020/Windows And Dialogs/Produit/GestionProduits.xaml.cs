﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace TP3_2019_2020.Windows_And_Dialogs.Produit
{
    /// <summary>
    /// Interaction logic for GestionProduits.xaml
    /// </summary>
    public partial class GestionProduits : Window
    {
        private MainWindow _owner;

        public GestionProduits()
        {
            _owner = Owner as MainWindow;
            InitializeComponent();
            //ListBoxProduit.DataContext = _owner.MyData;
            ListBoxDonnéesProduit.DataContext = ListBoxProduit;
        }

        private void Ajout_Click(object sender, RoutedEventArgs e)
        {
            AjoutProduit win = new AjoutProduit();
            win.Show();
            this.Hide();
        }




        private void CheckBox_Checked1(object sender, RoutedEventArgs e)
        {
            BoxParDate.IsChecked = false;
            ListBoxProduit.DataContext = _owner.MyData.ListArticle.OrderBy(d => d.DateCreation);
        }


        private void CheckBox_Checked3(object sender, RoutedEventArgs e)
        {
            BoxParNom.IsChecked = false;
            ListBoxProduit.DataContext = _owner.MyData.ListArticle.OrderBy(d => d.Nom);
        }


        private void Supprimer_Click(object sender, RoutedEventArgs e)
        {
            _owner.MyData.ListProduit.Remove((TP3_2019_2020.Objetcs.Produit)ListBoxProduit.SelectedItem);
        }

        private void Modifier_Click(object sender, RoutedEventArgs e)
        {
            AjoutProduit win = new AjoutProduit((TP3_2019_2020.Objetcs.Produit)ListBoxProduit.SelectedItem);
            win.Show();
            this.Hide();
        }

        public void AddToProduitList(Objetcs.Produit p)
        {
            _owner.MyData.ListProduit.Add(p);
        }

    }
}