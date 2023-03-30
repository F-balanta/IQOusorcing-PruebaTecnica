using IQOUTSOURCING.Domain.DTOs.Base;

namespace IQOUTSOURCING.Domain.DTOs.Usuario
{
    public class UsuarioCommandDTO : BaseUniversalDTO
    {
        public string? Nombre { get; set; }
        public string? UserName { get; set; }
        public string? Correo { get; set; }
        public string? Password { get; set; }
    }
}
