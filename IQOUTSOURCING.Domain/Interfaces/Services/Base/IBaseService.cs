using IQOUTSOURCING.Domain.DTOs.Base;
using IQOUTSOURCING.Domain.Entities.Base;

namespace IQOUTSOURCING.Domain.Interfaces.Services.Base
{
    public interface IBaseService<DTO, DTOC, T> where DTO : BaseDTO where DTOC : BaseUniversalDTO where T : Entity
    {
        Task<Response<ICollection<DTO>>> GetAll();
        Task<Response<DTO>> Add(DTOC entityDTO);
        Task<Response<DTO>> GetById(Guid id);
        Task<Response<DTO>> Update(Guid id, DTOC entityDTO);
        Task<Response<int>> Delete(Guid id);
    }
}
