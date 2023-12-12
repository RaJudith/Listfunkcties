using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Microsoft.VisualBasic;

namespace Oefening47
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Declaratie list:
        List<string> namen;

        public MainWindow()
        {
            InitializeComponent();

            string[] voornamenArray = new string[8] {"Wouter","Paul","Andreas","Niels","Kathleen","Paul","Silvia","Patricia" };

            // Initialisatie list:
            namen = new List<string>(voornamenArray);
            // OF
            namen = new List<string>();
            namen.AddRange(voornamenArray);
            // OF
            namen = new List<string>() { "Wouter", "Paul", "Andreas", "Niels", "Kathleen", "Paul", "Silvia", "Patricia" };

            // Toon lijst in ListBox
            ToonList();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            string item = ToonPrompt("Toevoegen", "Naam: ");

            namen.Add(item);
            ToonList();
        }

        private void BtnInsert_Click(object sender, RoutedEventArgs e)
        {
            string item = ToonPrompt("Toevoegen", "Naam: ");
            if(int.TryParse(ToonPrompt("Toevoegen", "Positie: "), out int position)) 
            {
                namen.Insert(position, item);
                ToonList();
            }
            else
            {
                MessageBox.Show("Geen geldige positie.");
            }
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            string item = ToonPrompt("Verwijderen", "Naam: ");

            namen.Remove(item);
            ToonList();
        }

        private void BtnSort_Click(object sender, RoutedEventArgs e)
        {
            namen.Sort();
            ToonList();
        }

        private void BtnToArray_Click(object sender, RoutedEventArgs e)
        {
            ToonArray(namen.ToArray());
        }

        private void BtnFind_Click(object sender, RoutedEventArgs e)
        {
            string item = ToonPrompt("Zoeken", "Naam: ");

            TxtResult.Text = namen.IndexOf(item).ToString();
            LbxNamenLijst.SelectedIndex = namen.IndexOf(item);
        }

        private string ToonPrompt(string title, string text)
        {
            string input = string.Empty;

            do
            {
                input = Interaction.InputBox(text, title);
            } while (string.IsNullOrEmpty(input));

            return input;
        }

        private void ToonList()
        {
            LbxNamenLijst.Items.Clear();
            for (int i = 0; i < namen.Count; i++)
            {
                ListBoxItem item = new ListBoxItem();
                item.Content = namen[i];
                LbxNamenLijst.Items.Add(item);
            }
            //foreach(string naam in namen)
            //{
            //    ListBoxItem item = new ListBoxItem();
            //    item.Content = naam;
            //    LbxNamenLijst.Items.Add(item);
            //}
        }

        private void ToonArray(string[] array)
        {
            LbxNamenArray.Items.Clear();
            for(int i = 0; i < array.Length; i++)
            {
                ListBoxItem item = new ListBoxItem();
                item.Content = array[i];
                LbxNamenArray.Items.Add(item);
            }
        }
    }
}
