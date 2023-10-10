using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel.Design;

namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            return services;
        }
    }
}
