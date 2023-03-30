using IQOUTSOURCING.BusinessLogic.Services;
using IQOUTSOURCING.Domain.DTOs.Auditoria;
using IQOUTSOURCING.Domain.DTOs.Usuario;
using IQOUTSOURCING.Domain.Entities;
using IQOUTSOURCING.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace IQOUTSOURCING.BusinessLogic.Extensions
{
    public static class BusinessExtensionServices
    {
        public static void AddBusinessExtensionServices(this IServiceCollection services)
        {
            services.AddScoped<IUsuarioService<UsuarioDTO, UsuarioCommandDTO, Usuario, UsuarioDataDTO, UsuarioLoginDTO>, UsuarioService>();
            services.AddScoped<IAuditoriaService<AuditoriaDTO>, AuditoriaService>();
            services.AddScoped<IPasswordHasher<Usuario>, PasswordHasher<Usuario>>();
        }

    }
}
