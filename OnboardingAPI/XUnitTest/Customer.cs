using CustomerAPI.CustomerAPI.Models.DTOs;
using CustomerAPI.CustomerAPI.Services.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XUnitTest
{
    public class Customer
    {
        private Mock<IHttpGenericFactory> _mockFactory;

        public Customer()
        {
            _mockFactory = new Mock<IHttpGenericFactory>();
           
        }



        public async Task BankTest()
        {
            var urlDto = new HttpGetOrDelete()
            {
                BaseUrl = "https://wema-alatdev-apimgt.azure-api.net/alat-test/api/Shared/GetAllBanks"
            };
          
        }
    }
}
