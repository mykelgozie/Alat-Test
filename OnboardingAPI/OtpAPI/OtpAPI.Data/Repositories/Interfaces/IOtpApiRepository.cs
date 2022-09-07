using OtpAPI.OtpAPI.Models;
using System.Threading.Tasks;

namespace OtpAPI.OtpAPI.Data.Repositories.Interfaces
{
    public interface IOtpApiRepository
    {
        Task<OtpUser> GetUser(string id);
        Task<Otp> GetOtp(string otpCode);
        void DeleteOtp(string otpId);
        Task<Otp> GetOtpByPhoneNumber(string phonumber);
        void UpdateOtp(Otp otp);
        void AddOtp(Otp otp);
        Task<Otp> GetOtpByCodeAndPhoneNumber(string phonumber, string code);
    }
}
