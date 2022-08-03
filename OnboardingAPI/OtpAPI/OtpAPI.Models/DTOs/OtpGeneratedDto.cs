using Microsoft.AspNetCore.Identity;
using System;

namespace OtpAPI.OtpAPI.Models.DTOs
{
    public class OtpGeneratedDto
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public int OtpCounter { get; set; } = 0;
        public string OtpCode { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
