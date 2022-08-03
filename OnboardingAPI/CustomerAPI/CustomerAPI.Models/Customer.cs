using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;

namespace CustomerAPI.CustomerAPI.Models
{
    public class Customer : IdentityUser
    {
        [Required(ErrorMessage = "First name is a required field.")]
        [StringLength(15, MinimumLength = 3, ErrorMessage = "Must be between 3 and 15")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last name is a required field.")]
        [StringLength(15, MinimumLength = 3, ErrorMessage = "Must be between 3 and 15")]
        public string LastName { get; set; }
        public string Gender { get; set; }
        public bool IsActive { get; set; } = false;
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public DateTime DateUpdated { get; set; } = DateTime.Now;

        
        public Address Address { get; set; }


    }
}
