using IQOUTSOURCING.Domain.DTOs.Base;

namespace IQOUTSOURCING.Domain.DTOs.Usuario
{
    public class UsuarioLoginDTO : BaseUniversalDTO
    {
        public string? UserName { get; set; }
        public string? Password { get; set; }
    }
}
