using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XamarinFirst.Api.Data;
using XamarinFirst.Api.Models;

namespace XamarinFirst.Api.Controllers
{
    [Route("api/Customers")]
    public class CustomersController : Controller
    {
        MyDbContext db;

        public CustomersController(MyDbContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public List<Customer> Get()
        {
            return db.Customers.ToList();
        }

        [HttpPost]
        public Customer Post(Customer customer)
        {
            db.Add(customer);
            db.SaveChanges();
            return customer;
        }

        //Update
        [HttpPut]
        public Customer Update(Customer customer)
        {
            db.Update(customer);
            db.SaveChanges();
            return customer;
        }

        [HttpDelete]
        public bool Delete(int id)
        {
            var customer = db.Customers
                             .Where(c => c.Id == id)
                             .Single();
            db.Remove(customer);
            return true;
        }
    }
}
