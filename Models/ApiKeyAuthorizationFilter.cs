using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace ServiceFilterBasic.Models
{
    public class ApiKeyAuthorizationFilter : IAuthorizationFilter
    {
        private const string APIKEY = "x-api-key";
        private readonly string _apikey;

        public ApiKeyAuthorizationFilter(IConfiguration configuration)
        {
            _apikey = configuration["ApiKey"].ToString();
        }


        // interface IAuthorizationFilter <-
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (!context.HttpContext.Request.Headers.TryGetValue(APIKEY, out var extractedApiKey))
            {
                context.Result = new UnauthorizedResult();
                return;
            }
            if (!_apikey.Equals(extractedApiKey))
            {
                context.Result = new UnauthorizedResult();
            }
        }

    }
}

