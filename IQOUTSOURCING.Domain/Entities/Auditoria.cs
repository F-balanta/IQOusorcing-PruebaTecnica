using IQOUTSOURCING.Domain.Entities.Base;

namespace IQOUTSOURCING.Domain.Entities
{
    public class Auditoria : BaseEntity
    {
        public Guid UsuarioId { get; set; }
        public DateTime FechaInicioSesion { get; set; } = DateTime.Now;
        public Usuario? Usuario { get; set; }

    }
}
