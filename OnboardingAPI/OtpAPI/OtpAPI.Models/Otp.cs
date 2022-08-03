using System;

namespace OtpAPI.OtpAPI.Models
{
    public class Otp
    {
        public string Id { get; set; } 
        public string OtpCode { get; set; }
        public OtpUser OtpUser { get; set; }
        public int OtpCounter { get; set; } = 0;
        public DateTime CreatedAt { get; set; }
        public DateTime LastUpdatedAt { get; set;} = DateTime.Now;
    }
}
