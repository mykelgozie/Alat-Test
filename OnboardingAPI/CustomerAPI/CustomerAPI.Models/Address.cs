using System;
using System.ComponentModel.DataAnnotations;

namespace CustomerAPI.CustomerAPI.Models
{
    public class Address 
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Street{ get; set; }
        public string StateOfResidence { get; set; }
        public string LocalGovernmentArea { get; set; }
    }
}