using Microsoft.Extensions.DependencyInjection;

namespace IQOUTSOURCING.Mappers.Extensions
{
    public static class MappingServices
    {
        public static void AddMappingServices(this IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }
    }
}
