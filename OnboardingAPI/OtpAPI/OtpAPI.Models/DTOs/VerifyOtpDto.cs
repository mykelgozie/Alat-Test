using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OtpAPI.OtpAPI.Models.DTOs
{
    public class VerifyOtpDto
    {
        public string PhoneNumber { get; set; }
        public string OtpCode { get; set; }
    }
}
