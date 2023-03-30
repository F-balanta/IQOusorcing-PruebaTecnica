using IQOUTSOURCING.Domain.DTOs.Base;
using IQOUTSOURCING.Domain.DTOs.Usuario;

namespace IQOUTSOURCING.Domain.DTOs.Auditoria
{
    public class AuditoriaDTO : BaseDTO
    {
        public DateTime FechaInicioSesion { get; set; }
        public UsuarioDTO? Usuario { get; set; }

    }
}
