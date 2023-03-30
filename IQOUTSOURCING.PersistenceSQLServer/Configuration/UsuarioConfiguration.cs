using IQOUTSOURCING.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IQOUTSOURCING.PersistenceSQLServer.Configuration
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {

            builder.Property(x => x.UserName).IsRequired().HasMaxLength(40);
            builder.Property(x => x.Password).IsRequired().HasMaxLength(500);
            builder.Property(x => x.Correo).IsRequired().HasMaxLength(40);
            builder.Property(x => x.Nombre).IsRequired().HasMaxLength(50);


            builder
                .HasMany(x => x.Roles)
                .WithMany(x => x.Usuarios)
                .UsingEntity<UsuariosRoles>(
                    x => x
                        .HasOne(x => x.Rol)
                        .WithMany(x => x.UsuariosRoles)
                        .HasForeignKey(x => x.RolId),
                    x => x
                        .HasOne(x => x.Usuario)
                        .WithMany(x => x.UsuariosRoles)
                        .HasForeignKey(x => x.UsuarioId),
                    x =>
                    {
                        x.HasKey(x => new { x.UsuarioId, x.RolId });
                    });
        }
    }
}
