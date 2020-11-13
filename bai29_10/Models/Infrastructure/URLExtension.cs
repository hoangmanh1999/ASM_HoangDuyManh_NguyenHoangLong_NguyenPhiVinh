using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
namespace bai29_10.Models.Infrastructure
{
    public static class URLExtension
    {
        public static string PathAndQuery(this HttpRequest request)
            => request.QueryString.HasValue
            ? $"{request.Path}{request.QueryString}" : request.Path.ToString();
    }
}
