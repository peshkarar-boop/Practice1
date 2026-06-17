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
    public partial class User : Page
    {
        public User()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
            MainViewModel.Updated += RefreshData;
        }

        private void RefreshData ()
        {
            var vm = (MainViewModel)DataContext;
            var NewData = vm.AllUsers;
            UsersListView.ItemsSource = null;
            UsersListView.ItemsSource = NewData.DefaultView;
        }

        private void OpenRestaurantPage(object sender, RoutedEventArgs e)
        {
            Users.Navigate(new Restaurant());
        }

        private void OpenOrderPage(object sender, RoutedEventArgs e)
        {
            Users.Navigate(new Order());
        }
        private void AddUser(object sender, RoutedEventArgs e)
        {
            AddUser addUser = new AddUser();
            addUser.Show();
        }
        private void DeleteUser(object sender, RoutedEventArgs e)
        {
            DeleteUser DeleteUser = new DeleteUser();
            DeleteUser.Show();
        }
    }
}
