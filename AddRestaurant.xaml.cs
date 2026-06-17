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
using System.Windows.Shapes;

namespace Kursovaia
{
    public partial class AddRestaurant : Window
    {
        private DatabaseHelper _db = new DatabaseHelper();
        public AddRestaurant()
        {
            InitializeComponent();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            string Name = NameTextBox.Text;
            string Address = AddressTextBox.Text;
            string Phone = PhoneTextBox.Text;

            if (string.IsNullOrWhiteSpace(Name))
            {
                MessageBox.Show("Введите 'Название ресторана'!", "Ошибка");
                return;

            }
            if (!Name.All(char.IsLetter))
            {
                MessageBox.Show("Запись 'Название ресторана' должна содержать буквы!", "Ошибка");
                return;
            }
            if (string.IsNullOrWhiteSpace(Address))
            {
                MessageBox.Show("Введите 'Адрес'!", "Ошибка");
                return;

            }
            if (string.IsNullOrWhiteSpace(Phone))
            {
                MessageBox.Show("Введите 'Телефон'!", "Ошибка");
                return;

            }
            if (Phone.Any(char.IsLetter))
            {
                MessageBox.Show("Запись 'Телефон' не должна содержать буквы!", "Ошибка");
                return;
            }
            _db.AddRestaurant(Name, Address, Phone);

            MessageBox.Show("Ресторан добавлен");

            this.Close();
        }
        private void Cancell_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}