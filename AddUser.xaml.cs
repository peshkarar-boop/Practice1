using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
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
    public partial class AddUser : Window
    { 
      private DatabaseHelper _db = new DatabaseHelper();
        public AddUser()
        {
              InitializeComponent();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {            
            string surname = SurnameTextBox.Text;
            string Fisrt_name = First_nameTextBox.Text;
            string Middle_name = Middle_nameTextBox.Text;
            string Phone = PhoneTextBox.Text;
            string Address = AddressTextBox.Text;

            if (string.IsNullOrWhiteSpace(surname))
            {
                MessageBox.Show("Введите 'Фамилия'!", "Ошибка");
                return;

            }
            if (!surname.All(char.IsLetter))
            {
                MessageBox.Show("Запись 'Фамилия' должна содержать буквы!", "Ошибка");
                return;
            }
                if (string.IsNullOrWhiteSpace(Fisrt_name))
            {
                MessageBox.Show("Введите 'Имя'!", "Ошибка");
                return;

            }
            if (!Fisrt_name.All(char.IsLetter))
            {
                MessageBox.Show("Запись 'Имя' должна содержать буквы!", "Ошибка");
                return;
            }
            if (string.IsNullOrWhiteSpace(Middle_name))
            {
                MessageBox.Show("Введите 'Отчество'!", "Ошибка");
                return;

            }
            if (!Middle_name.All(char.IsLetter))
            {
                MessageBox.Show("Запись 'Отчество' должна содержать буквы!", "Ошибка");
                return;
            }
            if (string.IsNullOrWhiteSpace(Phone))
            {
                MessageBox.Show("Введите 'Телефон'!", "Ошибка");
                return;

            }
            if (Phone.All(char.IsLetter))
            {
                MessageBox.Show("Запись 'Телефон' должна состоять из цифр!", "Ошибка");
                return;
            }
            if (!(string.IsNullOrWhiteSpace(Address)) && !(Address.Any(char.IsLetter)))
            {
                MessageBox.Show("Запись 'Адрес' должна содержать буквы либо быть пустой!", "Ошибка");
                return;
            }
            _db.AddUser(surname, Fisrt_name, Middle_name, Phone, Address);

            MessageBox.Show("Пользователь добавлен");

            this.Close();
        }
                

        private void Cancell_Click(object sender, RoutedEventArgs e)
        {
            this.Close();  
        }
    }
}