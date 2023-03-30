using IQOUTSOURCING.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace IQOUTSOURCING.PersistenceSQLServer.DataContext
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Rol>().HasData(new Rol { Nombre = "Usuario" });

            modelBuilder.ApplyConfigurationsFromAssembly(AppDomain.CurrentDomain.GetAssemblies().Single(x => x.GetName().Name == "IQOUTSOURCING.PersistenceSQLServer"));
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Usuario>? Usuarios { get; set; }
        public DbSet<Rol>? Roles { get; set; }
        public DbSet<Auditoria>? Auditoria { get; set; }
        public DbSet<UsuariosRoles>? UsuariosRoles { get; set; }


    }
}
