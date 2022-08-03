using CustomerAPI.CustomerAPI.Models.DTOs;
using CustomerAPI.CustomerAPI.Models.Enums;
using CustomerAPI.CustomerAPI.Services.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CustomerAPI.CustomerAPI.Services.Implementations
{
    public class HttpGenericFactory : IHttpGenericFactory
    {

        private readonly IHttpClientFactory _clientFactory;
        private readonly ILogger<HttpGenericFactory> _logger;
        public HttpGenericFactory(IHttpClientFactory clientFactory, ILogger<HttpGenericFactory> logger)
        {
            _clientFactory = clientFactory;
            _logger = logger;
        }


        public async Task<Tuple<bool, string>> Get(HttpGetOrDelete httpGetOrDelete, string basicAuthCredentials = "", string token = "")
        {
            HttpResponseMessage response = null;

            try
            {
                string requestUri = httpGetOrDelete.EndPoint + httpGetOrDelete.QueryString;
                var customeHeaders = httpGetOrDelete.CustomHeaders;

                using (var client = _clientFactory.CreateClient())
                using (var request =
                    new HttpRequestMessage((httpGetOrDelete.ApiHttpVerbs == ApiHttpVerbs.Get) ? HttpMethod.Get : HttpMethod.Delete, requestUri))
                {
                    client.BaseAddress = new Uri(httpGetOrDelete.BaseUrl);

                    if (!string.IsNullOrWhiteSpace(basicAuthCredentials))
                    {
                        var byteArray = Encoding.ASCII.GetBytes(basicAuthCredentials);
                        client.DefaultRequestHeaders.Authorization =
                            new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
                    }
                    else if (!string.IsNullOrWhiteSpace(token))
                    {
                        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    }

                    if (customeHeaders != null)
                        foreach (var customHeader in customeHeaders)
                            client.DefaultRequestHeaders.Add(customHeader.Name, customHeader.Value);

                    switch (httpGetOrDelete.ApiHttpVerbs)
                    {
                        case ApiHttpVerbs.Get:
                            response = await client.SendAsync(request);
                            break;
                        case ApiHttpVerbs.Delete:
                            response = await client.DeleteAsync(requestUri);
                            break;
                    }

                    var result = await response.Content.ReadAsStringAsync();

                    return Tuple.Create(response.IsSuccessStatusCode, result);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw;
            }
            finally
            {
                response.Dispose();
            }

        }

    }
}
