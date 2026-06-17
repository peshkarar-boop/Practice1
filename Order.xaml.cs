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
    public partial class Order : Page
    {
        public Order()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
            MainViewModel.Updated += RefreshData;
        }

        private void RefreshData()
        {
            var vm = (MainViewModel)DataContext;
            var NewData = vm.AllOrdersUserRestaurant;
            OrdersListView.ItemsSource = null;
            OrdersListView.ItemsSource = NewData.DefaultView;
        }
        private void OpenUsersPage(object sender, RoutedEventArgs e)
        {
            Orders.Navigate(new User());
        }
        private void OpenRestaurantPage(object sender, RoutedEventArgs e)
        {
            Orders.Navigate(new Restaurant());
        }
        private void AddOrder(object sender, RoutedEventArgs e)
        {
            AddOrder addOrder = new AddOrder();
            addOrder.Show();
        }

        private void DeleteOrder(object sender, RoutedEventArgs e)
        {
            DeleteOrder DeleteOrder = new DeleteOrder();
            DeleteOrder.Show();
        }
    }
}
