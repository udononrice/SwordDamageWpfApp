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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics;

namespace SwordDamageWpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Random random= new Random();
        SwordDamage swordDamage;

        public MainWindow()
        {
            InitializeComponent();
            swordDamage = new SwordDamage(random.Next(1, 7) + random.Next(1, 7) + random.Next(1, 7));
            DisplayDamage();
        }

        public void RollDice()
        {
            swordDamage.Roll = random.Next(1, 7) + random.Next(1, 7) + random.Next(1, 7);
            DisplayDamage();
        }

        void DisplayDamage()
        {
            damage.Text = $"Выпало {swordDamage.Roll} для урона на {swordDamage.Damage} HP.";
        }

        private void flaming_Checked(object sender, RoutedEventArgs e)
        {
            swordDamage.Flaming = true;
            DisplayDamage();
        }

        private void flaming_Unchecked(object sender, RoutedEventArgs e)
        {
            swordDamage.Flaming = false;
            DisplayDamage();
        }

        private void magic_Checked(object sender, RoutedEventArgs e)
        {
            swordDamage.Magic = true;
            DisplayDamage();
        }

        private void magic_Unchecked(object sender, RoutedEventArgs e)
        {
            swordDamage.Magic = false;
            DisplayDamage();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            RollDice();
        }
    }
}
