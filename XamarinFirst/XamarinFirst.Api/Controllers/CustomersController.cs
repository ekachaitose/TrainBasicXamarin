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
        public string Get()
        {
            string x = "success";
            try
            {
                db.Customers.ToList();
            }
            catch (Exception ex)
            {
                x = ex.Message;
            }
            return x;
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
            db.SaveChanges();
            return true;
        }
    }
}
