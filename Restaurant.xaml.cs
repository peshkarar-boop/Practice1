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
    public partial class Restaurant : Page
    {
        public Restaurant()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
            MainViewModel.Updated += RefreshData;
        }

        private void RefreshData()
        {
            var vm = (MainViewModel)DataContext;
            var NewData = vm.AllRestaurants;
            RestaurantListView.ItemsSource = null;
            RestaurantListView.ItemsSource = NewData.DefaultView;
        }

        private void OpenUsersPage(object sender, RoutedEventArgs e)
        {
            Restaurants.Navigate(new User());
        }
        private void OpenOrderPage(object sender, RoutedEventArgs e)
        {
            Restaurants.Navigate(new Order());
        }
                private void AddRestaurant(object sender, RoutedEventArgs e)
        {
            AddRestaurant addRestaurant = new AddRestaurant();
            addRestaurant.Show();
        }
        private void DeleteRestaurant(object sender, RoutedEventArgs e)
        {
            DeleteRestaurant DeleteRestaurant = new DeleteRestaurant();
            DeleteRestaurant.Show();
        }
    }
}
