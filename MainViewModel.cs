using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursovaia
{
    public class MainViewModel
    {
        private static DatabaseHelper _db = new DatabaseHelper();
        
        public DataTable AllUsers 
        { 
            get { return _db.GetUser(); } 
        }
        public DataTable AllRestaurants
        {
            get { return _db.GetRestaurants(); }
        }
                
        public DataTable AllOrdersUserRestaurant
        {
            get { return _db.GetOrdersUserRestaurant(); }
        }

        public DataTable AllOrderUsers
        {
            get { return _db.GetOrderUsers(); }
        }

        public DataTable AllOrderRestaurant
        {
            get { return _db.GetOrderRestaurant(); }
            
        }
        
        public static event Action Updated;
        public static void NotifyUpdated()
        { 
        Updated?.Invoke();
        }
    }
}
