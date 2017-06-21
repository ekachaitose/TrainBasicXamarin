using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace XamarinFirst.Api.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(200)]
        [Required]
        public string Name { get; set; }
        [MaxLength(200)]
        [Required]
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

        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }



    }
}
