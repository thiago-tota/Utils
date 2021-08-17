using Refit;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Tota.SharedKernel.RestClient
{
    public static class RefitClient
    {
        public static RefitSettings GetRestClientSettings(Func<Task<string>> authenticationDelegate = null, Func<HttpResponseMessage, Task<Exception>> exceptionDelegate = null)
        {
            var settings = new RefitSettings
            {
                ContentSerializer = new SystemTextJsonContentSerializer(
                   JsonSerializer.SystemTextJsonSerializer.GetOptionsToSerialize(false))
            };

            if (authenticationDelegate != null)
                settings.AuthorizationHeaderValueGetter = () => authenticationDelegate();

            if (exceptionDelegate != null)
                settings.ExceptionFactory = (HttpResponseMessage response) => exceptionDelegate(response);

            return settings;
        }
    }
}
