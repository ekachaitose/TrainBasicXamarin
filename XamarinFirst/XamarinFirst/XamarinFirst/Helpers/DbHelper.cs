using SQLite.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamarinFirst.Models;
using System.Linq;
using System.Collections.Generic;

namespace XamarinFirst.Helpers
{
    class DbHelper
    {
        private static DbHelper current;
        public static DbHelper Current
        {
            get
            {
                if (current == null) current = new DbHelper();
                return current;
            }
        }

        private SQLiteConnection db;
        private DbHelper()
        {
            var platform = DependencyService.Get<IPlatformHelper>();
            db = new SQLiteConnection(platform.GetSQLitePlatform(), platform.GetDbPath());
            db.CreateTable<Customer>();
        }

        public int CustomerAdd(Customer customer)
        {
           return  db.Insert(customer);
        }
        public int CustomerUpdate(Customer customer)
        {
            return db.Update(customer);
        }
        public int CustomerDelete(Customer customer)
        {
            return db.Delete(customer);
        }

        public List<Customer> CustomerGet()
        {
            return db.Table<Customer>()
                    .OrderBy(c => c.Name)
                    .ToList();
        }

        public Customer CustomerGet(int id)
        {
            return db.Table<Customer>()
                     .Where(c => c.Id == id)
                     .Single();
        }

        public List<Customer> CustomerSearch(string searchText)
        {
            searchText = searchText.Trim();
            return db.Table<Customer>()
                     .Where(c => c.Name.Contains(searchText) || c.Surname.Contains(searchText) || c.Telephone.Contains(searchText))
                     .OrderBy(c => c.Name)
                     .ToList();
        }
    }
}
