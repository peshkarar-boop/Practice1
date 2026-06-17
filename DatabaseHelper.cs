using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Xml.Linq;

namespace Kursovaia
{

    public class DatabaseHelper
    {

        private string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog = Курсовой; 
                                     Integrated Security = True;";

        public DataTable GetUser()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT [Surname],[First_name]," +
                               "[Middle_name],[Phone],[Address] FROM [dbo].[User]";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                adapter.Fill(dt);
            }
            return dt;
        }
        public void DeleteUser()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "INSERT INTO [dbo].[User] ([Surname],[First_name]," +
                               "[Middle_name],[Phone],[Address]) VALUES" +
                               "(@Surname, @First_name, @Middle_name, @Phone, @Address)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
            }
            MainViewModel.NotifyUpdated();
        }
        public DataTable GetOrderUsers()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT [ID_User], [Surname],[First_name],[Middle_name],[Address]," +
                               "([Surname] + ' ' + [First_name] + ' ' + [Middle_name]) " +
                               "AS [Full_Name] FROM [dbo].[User]";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                adapter.Fill(dt);
            }
            return dt;
        }

        public DataTable GetOrderRestaurant()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT [ID_Restaurant],([Name] + ', address: ' " +
                               "+ [Address]) AS [Information] FROM[dbo].[Restaurant]";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                adapter.Fill(dt);
            }
            return dt;
        }

        public DataTable GetOrders()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT [ID_User],[ID_Restaurant],[Order_date],[IS_Delivery],[Delivery_address],[TotalPrice],[Status] FROM [dbo].[Order2]";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                adapter.Fill(dt);
            }
            return dt;
        }

        public DataTable GetRestaurants()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT [Name],[Address],[Phone] FROM [dbo].[Restaurant]";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                adapter.Fill(dt);
            }
            return dt;
        }

        public void AddUser(string Surname, string First_name, string Middle_name, string Phone, string Address)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "INSERT INTO [dbo].[User] ([Surname],[First_name]," +
                               "[Middle_name],[Phone],[Address]) VALUES" +
                               "(@Surname, @First_name, @Middle_name, @Phone, @Address)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Surname", Surname);
                cmd.Parameters.AddWithValue("@First_name", First_name);
                cmd.Parameters.AddWithValue("@Middle_name", Middle_name);
                cmd.Parameters.AddWithValue("@Phone", Phone);
                cmd.Parameters.AddWithValue("@Address", Address);
                cmd.ExecuteNonQuery();
            }
            MainViewModel.NotifyUpdated();
        }

        public void AddOrder(int ID_User, int ID_Restaurant, DateTime Order_date, string Is_Delivery,
                    string Delivery_address, int TotalPrice, string Status)
        {

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "INSERT INTO [dbo].[Order2] ([ID_User],[ID_Restaurant],[Order_date]," +
                               "[Is_Delivery],[Delivery_address],[TotalPrice],[Status]) VALUES" +
                               "(@ID_User, @ID_Restaurant, @Order_date, @Is_Delivery, " +
                               "@Delivery_address, @TotalPrice, @Status)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ID_User", ID_User);
                cmd.Parameters.AddWithValue("@ID_Restaurant", ID_Restaurant);
                cmd.Parameters.AddWithValue("@Order_date", Order_date);
                cmd.Parameters.AddWithValue("@Is_Delivery", Is_Delivery);
                cmd.Parameters.AddWithValue("@Delivery_address", Delivery_address);
                cmd.Parameters.AddWithValue("@TotalPrice", TotalPrice);
                cmd.Parameters.AddWithValue("@Status", Status);
                cmd.ExecuteNonQuery();
            }
            MainViewModel.NotifyUpdated();
        }



        public void AddRestaurant(string Name, string Address, string Phone)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "INSERT INTO [dbo].[Restaurant] (" +
                               "[Name],[Address],[Phone]) VAlUES" +
                               "(@Name, @Address, @Phone)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Name", Name);
                cmd.Parameters.AddWithValue("@Address", Address);
                cmd.Parameters.AddWithValue("@Phone", Phone);
                cmd.ExecuteNonQuery();
            }
            MainViewModel.NotifyUpdated();
        }

        public DataTable GetOrdersUserRestaurant()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT [Order2].[Order_date],[Order2].[IS_Delivery],[Order2].[Delivery_address]," +
                    "[Order2].[TotalPrice],[Order2].[Status], [User]. [Surname],[User]. [First_name]," +
                    "[User]. [Middle_name],[User]. [Address], [Restaurant]. [Name],[Restaurant]. [Address] FROM [dbo].[Order2] " +
                    "JOIN [dbo].[User] ON [dbo].[User].[ID_User] = [dbo].[Order2].[ID_User]" +
                    "JOIN [dbo].[Restaurant] ON [dbo].[Order2].[ID_Restaurant] = [dbo].[Restaurant].[ID_Restaurant]";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                adapter.Fill(dt);
            }
            return dt;
        }                
    }
}