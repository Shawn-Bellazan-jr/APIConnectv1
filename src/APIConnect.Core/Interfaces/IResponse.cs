using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace APIConnect.Core.Interfaces
{
    public interface IResponse
    {
        // Add data properties for responses
        HttpStatusCode StatusCode { get; }
        RestResponse RestResponse { get; }
        Dictionary<string, string> Headers { get; }
        string Content { get; }
    }
}
