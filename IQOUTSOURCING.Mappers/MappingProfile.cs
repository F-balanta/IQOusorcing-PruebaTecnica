using AutoMapper;
using IQOUTSOURCING.Domain.DTOs.Auditoria;
using IQOUTSOURCING.Domain.DTOs.Usuario;
using IQOUTSOURCING.Domain.Entities;

namespace IQOUTSOURCING.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Usuario, UsuarioDTO>().ReverseMap();
            CreateMap<Usuario, UsuarioCommandDTO>().ReverseMap();
            CreateMap<UsuarioDTO, UsuarioCommandDTO>().ReverseMap();

            CreateMap<Auditoria, AuditoriaDTO>()
                .ForMember(x => x.Usuario, x => x.MapFrom(x => x.Usuario))
                .ReverseMap();
        }
    }
}
