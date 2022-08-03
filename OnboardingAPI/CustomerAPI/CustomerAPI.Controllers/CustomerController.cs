using AutoMapper;
using CustomerAPI.CustomerAPI.Commons.Helpers;
using CustomerAPI.CustomerAPI.Models;
using CustomerAPI.CustomerAPI.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CustomerAPI.CustomerAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly IMapper _mapper;
        private readonly UserManager<Customer> _userManager;

        public CustomerController(ICustomerService customerService, IMapper mapper, UserManager<Customer> userManager)
        {
            _customerService = customerService;
            _mapper = mapper;
            _userManager = userManager;
        }

        [HttpPost("add-customer")]
        public async Task<IActionResult> AddCustomer([FromBody] CustomerToAddDTO customer)
        {
            if (!ModelState.IsValid)
                return BadRequest(ResponseHelper.BuildResponse<object>(false, "Registration failed", ModelState, null));
            var response = await _customerService.AddCustomer(customer);
            return Ok(ResponseHelper.BuildResponse<object>(true, "Registerd successfully!", ResponseHelper.NoErrors, response));
        }
    }
}
 
