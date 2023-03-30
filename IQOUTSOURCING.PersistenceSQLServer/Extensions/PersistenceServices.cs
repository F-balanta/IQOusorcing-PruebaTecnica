using IQOUTSOURCING.Domain.Interfaces;
using IQOUTSOURCING.PersistenceSQLServer.DataAccess;
using IQOUTSOURCING.PersistenceSQLServer.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IQOUTSOURCING.PersistenceSQLServer.Extensions
{
    public static class PersistenceServices
    {
        public static void AddPersistenceServices(this IServiceCollection services, IConfiguration builder)
        {
            services.AddDbContext<Context>(x => x.UseSqlServer(builder.GetConnectionString("CadenaConexion")));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
