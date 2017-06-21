using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XamarinFirst.Api.Models;

namespace XamarinFirst.Api.Data
{
    public class MyDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }

        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {


        }
    }
}
