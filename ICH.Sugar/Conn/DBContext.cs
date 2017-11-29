using System;
using ICH.Core.Net;
using ICH.Core.Security;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;

namespace ICH.Sugar.Conn
{
    public class DBContext
    {
        public string DBUrl { get; set; }
        public string APIKey { get; set; }
    }
}
