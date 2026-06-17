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

namespace Kursovaia
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
                    }
        private void OpenUsersPage(object sender, RoutedEventArgs e)
        {
            Main.Navigate(new User());
        }

        private void OpenRestaurantPage(object sender, RoutedEventArgs e)
        {
            Main.Navigate(new Restaurant());
        }

        private void OpenOrderPage(object sender, RoutedEventArgs e)
        {
            Main.Navigate(new Order());
        }
    }
}
