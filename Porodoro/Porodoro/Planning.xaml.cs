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

namespace Porodoro
{
    /// <summary>
    /// Logique d'interaction pour Planning.xaml
    /// </summary>
    public partial class Planning : Page
    {
        string str;
        string tag;
        List<Pomodoro> items = new List<Pomodoro>();

        public Planning()
        {
            InitializeComponent();
            items.Add(new Pomodoro { Title = "Clientèle", Count = 3, Tags = "Client" });
            items.Add(new Pomodoro { Title = "Comptabilité", Count = 1, Tags = "Compta" });
            items.Add(new Pomodoro { Title = "Développement", Count = 9, Tags = "Dev" });
            PomodoroList.ItemsSource = items;
        }

        private void NavToTimer(object sender, RoutedEventArgs e)
        {
            str = Pomodoro.Text;
            Timer timer = new Timer(str);
            if(NavigationService.CanGoBack) { this.NavigationService.RemoveBackEntry(); }
            this.NavigationService.Navigate(timer);
        }

        private void AddPomodoro(object sender, RoutedEventArgs e)
        {
            str = Pomodoro.Text;
            tag = Tags.Text;
            items.Add(new Pomodoro { Title = str, Count = 0, Tags = tag });
            PomodoroList.ItemsSource = items;
            Console.WriteLine("Add pomodoro");
            Console.WriteLine(str);
            Console.WriteLine(tag);
        }
    }
}
