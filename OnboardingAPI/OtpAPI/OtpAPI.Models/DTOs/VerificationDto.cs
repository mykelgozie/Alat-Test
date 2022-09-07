using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OtpAPI.OtpAPI.Models.DTOs
{
    public class VerificationDto
    {
        [Required]
        public string PhoneNumber { get; set; }
    }
}
