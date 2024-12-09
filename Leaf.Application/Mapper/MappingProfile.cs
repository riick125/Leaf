using AutoMapper;
using Leaf.Application.Dtos;
using Leaf.Domain.Entidades;

namespace Leaf.Application.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Usuario, UsuarioDto>().ReverseMap();

            CreateMap<Evento, EventoDto>().ReverseMap();
        }
    }
}