using CustomerAPI.CustomerAPI.Models.DTOs;
using CustomerAPI.CustomerAPI.Services.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerAPI.CustomerAPI.Services.Implementations
{
    public class BankService : IBankService
    {
        private IHttpGenericFactory _httpGenericFactory;

        public BankService(IHttpGenericFactory httpGenericFactory)
        {
            _httpGenericFactory = httpGenericFactory;
        }


        public async Task<BankDto> GetBanksAsync()
        {
            var getBanks = await _httpGenericFactory.Get(new HttpGetOrDelete() 
            {
                BaseUrl = "https://wema-alatdev-apimgt.azure-api.net/alat-test/api/Shared/GetAllBanks"
            },"");

            var response = JsonConvert.DeserializeObject<BankDto>(getBanks.Item2);
            return response;
        }
    }
}
