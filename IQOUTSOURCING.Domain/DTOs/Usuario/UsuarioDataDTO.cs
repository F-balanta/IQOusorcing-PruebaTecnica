using IQOUTSOURCING.Domain.DTOs.Base;

namespace IQOUTSOURCING.Domain.DTOs.Usuario
{
    public class UsuarioDataDTO : BaseUniversalDTO
    {
        public Guid? Id{ get; set; }
        public string? UserName { get; set; }
        public string? Token{ get; set; }
    }
}
