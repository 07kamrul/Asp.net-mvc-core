using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace First_App.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Display(Name="Employee Name")]
        [Required]
        public string Name { get; set; }

        [Display(Name = "RegNo")]
        [Required]
        public string RegNo { get; set; }

        [EmailAddress]
        [Required]
        public string Email { get; set; }

        [Display(Name = "Address")]
        [Required]
        public string Address { get; set; }
    }
}
