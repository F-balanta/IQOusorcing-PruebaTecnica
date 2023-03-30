using IQOUTSOURCING.Domain.Entities.Base;

namespace IQOUTSOURCING.Domain.Entities
{
    public class UsuariosRoles : Entity
    {
        public Guid? UsuarioId { get; set; }
        public Usuario? Usuario{ get; set; }
        public Guid? RolId { get; set; }
        public Rol? Rol { get; set; }
    }
}