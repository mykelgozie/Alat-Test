using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using CustomerAPI.CustomerAPI.Models.DTOs;

namespace CustomerAPI.CustomerAPI.Commons.Helpers
{
    public static class ResponseHelper
    {
        public static ModelStateDictionary NoErrors = new ModelStateDictionary();
        public static ResponseDTO<T> BuildResponse<T>(bool status, string message, ModelStateDictionary errs, T data)
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
            var res = new ResponseDTO<T>
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
