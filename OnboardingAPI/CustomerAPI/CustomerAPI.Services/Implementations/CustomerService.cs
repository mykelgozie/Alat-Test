using AutoMapper;
using CustomerAPI.CustomerAPI.Models;
using CustomerAPI.CustomerAPI.Models.DTOs;
using CustomerAPI.CustomerAPI.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace CustomerAPI.CustomerAPI.Services.Implementations
{
    public class CustomerService : ICustomerService
    {
        private readonly UserManager<Customer> _userManager;
        private readonly IMapper _mapper;

        public CustomerService(UserManager<Customer> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;

        }
        public async Task<RegisterResponseDTO> AddCustomer(CustomerToAddDTO customer)
        {
            Customer mappedCustomer = new Customer()
            {
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Email = customer.Email,
                PhoneNumber = customer.PhoneNumber,
                UserName = customer.Email,
                Address = customer.Address,
                Gender = customer.Gender,

            };

            var addCustomerResult = await _userManager.CreateAsync(mappedCustomer, customer.Password);
            if (!addCustomerResult.Succeeded)
                return new RegisterResponseDTO { Tag = "CreateUserError", ErrorResult = addCustomerResult, Message = "Registration failed" };
            var customerToReturn = new CustomerToReturnDTO()
            { 
                 FirstName=customer.FirstName,
                 LastName=customer.LastName,
                 Email=customer.Email,
                 PhoneNumber=customer.PhoneNumber
            };
            return new RegisterResponseDTO { Tag = "Success", ErrorResult = null, Customer = customerToReturn };
        }
    }
}
