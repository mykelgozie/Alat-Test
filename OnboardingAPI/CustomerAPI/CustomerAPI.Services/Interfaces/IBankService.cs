using CustomerAPI.CustomerAPI.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerAPI.CustomerAPI.Services.Interfaces
{
    public interface IBankService
    {
        Task<BankDto> GetBanksAsync();
    }
}
