using OtpAPI.OtpAPI.Models;
using OtpAPI.OtpAPI.Models.DTOs;
using System.Threading.Tasks;

namespace OtpAPI.OtpAPI.Services.Interfaces
{
    public interface IOtpApiService
    {
        Task<OtpToReturnDto> VerifyPhoneNumber(string id, string phoneNumber);
        Task<OtpConfirmationToReturnDto> VerifyOtp(string otpCode);
        Task<Otp> RequestVerificationOTP(VerificationDto verificationDto);
        Task<OtpConfirmationToReturnDto> ValidateOTP(VerifyOtpDto verifyOtpDto);
    }
}
