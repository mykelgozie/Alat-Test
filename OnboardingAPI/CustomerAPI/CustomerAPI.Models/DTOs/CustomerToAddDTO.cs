using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerAPI.CustomerAPI.Models
{
    public class CustomerToAddDTO
    {
        
        [Required(ErrorMessage = "First name is a required field.")]
        [StringLength(15, MinimumLength = 3, ErrorMessage = "Must be between 3 and 15")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last name is a required field.")]
        [StringLength(15, MinimumLength = 3, ErrorMessage = "Must be between 3 and 15")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Gender is a required field.")]
        public string Gender { get; set; }
        public bool IsActive { get; set; } = false;
        [Required(ErrorMessage = "Email is a required field.")]
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "Password field cannot be empty")]
        [MinLength(6, ErrorMessage = "Password cannot be less than 6 characters.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Compare("Password", ErrorMessage = "Does not match password")]
        public string ConfirmPassword { get; set; }

        public Address Address { get; set; }

    }
}
