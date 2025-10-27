using CLINICA.APPLICATION.USECASES.Commons.Exceptions;
using CLINICA.PRESENTATION.API.Extensions.Middleware;

namespace CLINICA.PRESENTATION.API.Extensions
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder AddMiddleware(this IApplicationBuilder builder) {

            return builder.UseMiddleware<ValidationMiddleware>();
        }
    }
}
