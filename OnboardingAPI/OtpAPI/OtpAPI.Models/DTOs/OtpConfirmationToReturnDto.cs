using System;

namespace OtpAPI.OtpAPI.Models.DTOs
{
    public class OtpConfirmationToReturnDto
    {
        public string Id { get; set; }
        public bool Confirmation { get; set; }
        public string Status { get; set; }
    }
}
