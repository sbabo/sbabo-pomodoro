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

        public Planning()
        {
            InitializeComponent();
        }

        private void NavToTimer(object sender, RoutedEventArgs e)
        {
            str = Title.Text;
            Timer timer = new Timer(str);
            if(NavigationService.CanGoBack) { this.NavigationService.RemoveBackEntry(); }
            this.NavigationService.Navigate(timer);
        }
    }
}
