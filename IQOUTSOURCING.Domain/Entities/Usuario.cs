using IQOUTSOURCING.Domain.Entities.Base;
using System.Xml;

namespace IQOUTSOURCING.Domain.Entities
{
    public class Usuario : BaseEntity
    {
        public string? Nombre { get; set; }
        public string? UserName { get; set; }
        public string? Correo { get; set; }
        public string? Password { get; set; }

        public ICollection<Auditoria>? Auditorias { get; set; }
        public ICollection<Rol>? Roles { get; set; } = new HashSet<Rol>();
        public ICollection<UsuariosRoles>? UsuariosRoles { get; set; }

    }
}
