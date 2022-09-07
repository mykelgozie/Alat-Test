using System;

namespace OtpAPI.OtpAPI.Models
{
    public class Otp
    {
        public string Id { get; set; } 
        public string OtpCode { get; set; }
        public OtpUser OtpUser { get; set; }
        public int OtpCounter { get; set; } = 0;
        public string PhoneNumber { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ExpiresIn { get; set; }
        public bool IsVerified { get; set; }
        public DateTime LastUpdatedAt { get; set;} = DateTime.Now;
    }
}
