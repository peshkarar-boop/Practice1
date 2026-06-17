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
    public partial class AddOrder : Window
    {
        private DatabaseHelper _db = new DatabaseHelper();
        public AddOrder()
        {
            InitializeComponent();
            LoadUsers();
            DataContext = new MainViewModel();
        }

        private void LoadUsers() { 
        
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            
            string Is_Delivery = Is_DeliveryTextBox.Text;
            string Delivery_address = Delivery_addressTextBox.Text;
            string Status = StatusTextBox.Text;

            if (ID_UserComboBox.SelectedValue == null)
            {
                MessageBox.Show("ID пользователя не выбрано!", "Ошибка");
                return;
            }
            int ID_User = (int)ID_UserComboBox.SelectedValue; 

            if (ID_RestaurantComboBox.SelectedValue == null)
            {
                MessageBox.Show("ID ресторана не выбрано!", "Ошибка");
                return;
            }
            int ID_Restaurant = (int)ID_RestaurantComboBox.SelectedValue;

            if (!DateTime.TryParse(Order_dateTextBox.Text, out DateTime Order_date))
            {
                MessageBox.Show("Введите корректную дату в 'Дата заказа'(например, 2025-06-01 00:00:00)!", "Ошибка");
                return;

            }
            if (string.IsNullOrWhiteSpace(Is_Delivery) || 
                Is_Delivery != "Доставка" && Is_Delivery != "Самовывоз")
            {
                MessageBox.Show("'Доставка/Самовывоз' должен быть 'Доставка' или 'Самовывоз'!", "Ошибка");
                return;

            }

            if (Is_Delivery == "Доставка" || string.IsNullOrWhiteSpace(Delivery_address))
            {
                MessageBox.Show("Введите 'Адрес доставки' либо замените " +
                    "'Доставка' на 'Самовывоз' в строке Доставка/Самовывоз!", "Ошибка");
                return;
            }

            if (!int.TryParse(TotalPriceTextBox.Text, out int TotalPrice))
            {
                MessageBox.Show("Итоговая стоимость должен быть числом", "Ошибка");
                return;
            }
            if (string.IsNullOrWhiteSpace(Status))
            {
                MessageBox.Show("Введите 'Статус заказа'!","Ошибка");
                return;

            }
            if (!Status.All(char.IsLetter))
            {
                MessageBox.Show("Запись 'Статус заказа' должна содержать буквы!", "Ошибка");
                return;

            }

            _db.AddOrder(ID_User, ID_Restaurant, Order_date, Is_Delivery,
                    Delivery_address, TotalPrice, Status);

            MessageBox.Show("Заказ добавлен");

            this.Close();
        }


        private void Cancell_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}