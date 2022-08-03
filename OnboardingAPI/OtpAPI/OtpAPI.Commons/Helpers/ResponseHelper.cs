using Microsoft.AspNetCore.Mvc.ModelBinding;
using OtpAPI.OtpAPI.Models.DTO;
using System.Collections.Generic;

namespace OtpApi.Commons.Helpers
{
    public static class ResponseHelper
    {
        public static ModelStateDictionary NoErrors = new ModelStateDictionary();
        public static ResponseDto<T> BuildResponse<T>(bool status, string message, ModelStateDictionary errs, T data)
        {
            var errors = new List<ErrorItem>();
            if (errs != null)
            {
                foreach (var err in errs)
                {
                    var key = err.Key;
                    var errValues = err.Value;
                    var errList = new List<string>();
                    foreach (var errItem in errValues.Errors)
                        errList.Add(errItem.ErrorMessage);
                    errors.Add(new ErrorItem { Key = key, ErrorMessages = errList });
                }
            }
            var res = new ResponseDto<T>
            {
                Status = status,
                Message = message,
                Data = data,
                Errors = errors
            };
            return res;
        }
    }
}
