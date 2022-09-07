using Microsoft.AspNetCore.Mvc;
using OtpApi.Commons.Helpers;
using OtpAPI.OtpAPI.Models.DTOs;
using OtpAPI.OtpAPI.Services.Interfaces;
using System.Threading.Tasks;

namespace OtpApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class OtpController : ControllerBase
    {
        private readonly IOtpApiService _otpApiService;

        public OtpController(IOtpApiService otpApiService)
        {
            _otpApiService = otpApiService;
        }

        [HttpPost("verify-phone-number{Id}")]
        public async Task<IActionResult> VerifyPhoneNumber([FromRoute] string id, string phoneNumber)
        {
            var unVerifiedNumber = await _otpApiService.VerifyPhoneNumber(id, phoneNumber);
            if (unVerifiedNumber == null)
            {
                ModelState.AddModelError("Not found", "");
                return NotFound(ResponseHelper.BuildResponse<object>(false, "Account Doesn't Exist", ModelState, null));
            }
            return Ok(ResponseHelper.BuildResponse<object>(true, "An Otp Has Been Sent To Your Phone Number", ResponseHelper.NoErrors, unVerifiedNumber));
        }

        [HttpPost("verify-otp{otpCode}")]
        public async Task<IActionResult> VerifyOtp (string otpCode)
        {
            var unVerifiedOtp = await _otpApiService.VerifyOtp(otpCode);
            if (unVerifiedOtp == null)
            {
                ModelState.AddModelError("Not found", "");
                return NotFound(ResponseHelper.BuildResponse<object>(false, "Otp has expired", ModelState, null));
            }
            return Ok(ResponseHelper.BuildResponse<object>(true, "Phone number verified successfully", ResponseHelper.NoErrors, unVerifiedOtp));
        }

        [HttpPost("verifyNumber")]
        public async Task<IActionResult> VerifyNumber([FromBody] VerificationDto verificationDto)
        {
            var unVerifiedNumber = await _otpApiService.RequestVerificationOTP(verificationDto);
            if (unVerifiedNumber == null)
            {
                ModelState.AddModelError("Not found", "");
                return NotFound(ResponseHelper.BuildResponse<object>(false, "Account Doesn't Exist", ModelState, null));
            }
            return Ok(ResponseHelper.BuildResponse<object>(true, "An Otp Has Been Sent To Your Phone Number", ResponseHelper.NoErrors, unVerifiedNumber));
        }


        [HttpPost("Validate")]
        public async Task<IActionResult> Validate([FromBody] VerifyOtpDto verifyOtpDto)
        {
            var unVerifiedNumber = await _otpApiService.ValidateOTP(verifyOtpDto);
            if (unVerifiedNumber == null)
            {
                ModelState.AddModelError("Not found", "");
                return NotFound(ResponseHelper.BuildResponse<object>(false, "Account Doesn't Exist", ModelState, null));
            }
            var mssg = unVerifiedNumber.Confirmation ? "Verification Successful" : "Invalid Number";
            return Ok(ResponseHelper.BuildResponse<object>(true, $"{mssg}", ResponseHelper.NoErrors, unVerifiedNumber));
        }

    }
}
