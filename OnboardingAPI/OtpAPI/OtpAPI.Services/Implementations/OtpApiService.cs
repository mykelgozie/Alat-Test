using OtpApi.Commons.Helpers;
using OtpAPI.OtpAPI.Data.Repositories.Interfaces;
using OtpAPI.OtpAPI.Models;
using OtpAPI.OtpAPI.Models.DTOs;
using OtpAPI.OtpAPI.Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace OtpAPI.OtpAPI.Services.Implementations
{
    public class OtpApiService : IOtpApiService
    {
        private readonly IOtpApiRepository _otpApiRepository;

        public OtpApiService(IOtpApiRepository otpApiRepository )
        {
            _otpApiRepository = otpApiRepository;
        }

        public async Task<OtpToReturnDto> VerifyPhoneNumber(string id, string phoneNumber)
        {
            var unVerifiedNumber = await _otpApiRepository.GetUser(id);
            if (unVerifiedNumber == null) 
                return null;
            var otpCode = RandomNumberGenerator.GenerateRandomNumber();

            OtpToReturnDto returnDto = new OtpToReturnDto()
            {
                Id = unVerifiedNumber.Id,
                PhoneNumber = unVerifiedNumber.PhoneNumber,
                FirstName = unVerifiedNumber.FirstName,
                LastName = unVerifiedNumber.LastName,
                OtpCode = otpCode,
            };

            OtpGeneratedDto otpGeneratedDto = new OtpGeneratedDto()
            {
                Id = unVerifiedNumber.Id,
                OtpCode = otpCode,
            };

            Otp otp = new Otp()
            {
                Id = otpGeneratedDto.Id,
                OtpCounter = otpGeneratedDto.OtpCounter++,
                OtpCode = otpCode,
                OtpUser = unVerifiedNumber,
                CreatedAt = otpGeneratedDto.CreatedAt
            };
            return returnDto;
        }

       public enum currentStatus { Expired, Confirmed, }

        public async Task<OtpConfirmationToReturnDto> VerifyOtp(string otpCode)
        {
            var unUsedOtp = await _otpApiRepository.GetOtp(otpCode);
            if (unUsedOtp == null)
                return null;
            //Check if OTP has expires
            var createdTime = unUsedOtp.CreatedAt;
            var expTime = createdTime.AddMinutes(5);
            var currentTime = DateTime.Now;
            //var currentStat= "";

            if (currentTime > expTime)
            {
                var currentStat = currentStatus.Expired;
                _otpApiRepository.DeleteOtp(unUsedOtp.Id);
                return null;
            }
            
            var mappedresponse = new OtpConfirmationToReturnDto()
            {
                Id = unUsedOtp.OtpUser.Id,
                Status = "Comfirmed",
                Confirmation = true,
            };
            return mappedresponse;
        }
    }

}     
               
    

