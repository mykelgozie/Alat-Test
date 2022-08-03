using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerAPI.CustomerAPI.Models.DTOs
{
    public class CustomerToReturnDTO
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}
