using CustomerAPI.CustomerAPI.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerAPI.CustomerAPI.Services.Interfaces
{
    public interface IHttpGenericFactory
    {
        Task<Tuple<bool, string>> Get(HttpGetOrDelete httpGetOrDelete, string basicAuthCredentials = "", string token = "");
    }
}
