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
using System.Net.Http;
using Newtonsoft.Json.Linq;

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

        public async Task<int> CustomerAdd(Customer customer)
        {
            var param = new Dictionary<string, string>();
            param.Add("Name", customer.Name);
            param.Add("Surname", customer.Surname);
            param.Add("Birthdate", customer.Birthdate.ToString());
            param.Add("Email", customer.Email);
            param.Add("Telephone", customer.Telephone);
            param.Add("Ismarry", customer.IsMarry.ToString());
            param.Add("Salary", customer.Salary.ToString());
            param.Add("Children", customer.Children.ToString());
            param.Add("Gender", customer.Gender);
            param.Add("Photo", customer.Photo);
            param.Add("Address", customer.Address);
            param.Add("Website", customer.Website);
            param.Add("Username", customer.Username);
            param.Add("Password", customer.Password);

            var content = new FormUrlEncodedContent(param);
            var client = new HttpClient();
            var response = await client.PostAsync("http://codemobile.azurewebsites.net/api/Customers", content);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var json = await response.Content.ReadAsStringAsync();
                var cus = JObject.Parse(json).ToObject<Customer>();
                return cus.Id;
            }
            else return 0;
            
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
        public async Task FeedData()
        {
            var client = new HttpClient();
            var json = await client.GetStringAsync("http://codemobile.azurewebsites.net/api/Customers");
            var customers = JArray.Parse(json).ToObject<List<Customer>>();
            db.DeleteAll<Customer>();
            foreach (var item in customers)
            {
                db.Insert(item);
            }
        }
    }
}
