using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamarinFirst.Models
{
    [Table("Customers")]
    public class Customer
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(200), NotNull]
        public string Name { get; set; }

        [MaxLength(200), NotNull]
        public string Surname { get; set; }
        public DateTime Birthdate { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public bool? IsMarry { get; set; }
        public int? Salary { get; set; }
        public int? Children { get; set; }
        public string Gender { get; set; }
        public string Photo { get; set; }
        public string Address { get; set; }
        public string Website { get; set; }

        [Unique,NotNull]
        public string Username { get; set; }
        [NotNull]
        public string Password { get; set; }



    }
}
