using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIConnect.Core.Interfaces
{
    public interface IRequest
    {
        string Endpoint { get; set; }

        // Add data properties for requests
        Dictionary<string, string> Headers { get; set; }
        object Body { get; set; }
    }
}
