using CustomerAPI.CustomerAPI.Models;
using CustomerAPI.CustomerAPI.Models.DTOs;
using System.Threading.Tasks;

namespace CustomerAPI.CustomerAPI.Services.Interfaces
{
    public interface ICustomerService
    {
        Task<RegisterResponseDTO> AddCustomer(CustomerToAddDTO customer);
        //Task<List<CustomerToReturnDTO>>GetAllCustomers();
    }
}
