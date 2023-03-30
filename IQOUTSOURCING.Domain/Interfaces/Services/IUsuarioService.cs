using IQOUTSOURCING.Domain.DTOs.Base;
using IQOUTSOURCING.Domain.Entities.Base;
using IQOUTSOURCING.Domain.Interfaces.Services.Base;

namespace IQOUTSOURCING.Domain.Interfaces.Services
{
    public interface IUsuarioService<DTO, DTOC, T, DTOUserData, DTOUsuarioLogin> : IBaseService<DTO, DTOC, T> where DTO : BaseDTO where DTOC : BaseUniversalDTO where T : Entity where DTOUserData : BaseUniversalDTO where DTOUsuarioLogin : BaseUniversalDTO
    {
        Task<Response<DTOUserData>> GetToken(DTOUsuarioLogin entityDTO);
    }
}
