using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerAPI.CustomerAPI.Models.DTOs
{
    public class RegisterResponseDTO
    {
        public string Tag { get; set; }
        public string Key { get; set; }
        public string Message { get; set; }
        public IdentityResult ErrorResult { get; set; }
        public CustomerToReturnDTO Customer { get; set; }
    }
}
