using APIConnect.Core.Interfaces;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIConnect.Core.BaseClasses
{
    public class ApiClientBase: IApiClient
    {
        private readonly IRestClient _client;

        protected Dictionary<string, string> RequestHeaders { get; set; } = new Dictionary<string, string>();
        protected object RequestBody { get; set; }

        public ApiClientBase(IRestClient client) => _client = client;
        protected virtual TResponse HandleResponse<TResponse>(RestResponse<TResponse> response)
        {
            try
            {
                var data = response.Data;
                var isSuccessful = response.IsSuccessful;
                if (data != null && isSuccessful) return data;
            }
            catch(Exception e) {
                throw new InvalidOperationException("Response data is null, even though the request was successful.");
            }
            throw new Exception($"{response.StatusCode}, {response.Content}");
        }
    }
}
