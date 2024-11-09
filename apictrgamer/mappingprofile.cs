using AutoMapper;
using ctrgamer._03_entidades;
using ctrgamer._03_entidades.DTO.carrinho;
using ctrgamer._03_entidades.DTO.Categorias;
using ctrgamer._03_entidades.DTO.Compra;

namespace apictrgamer
{
    public class mappingprofile : Profile
    {
        public mappingprofile()
        {
            CreateMap<ReadCategoria, JogoCategoria>().ReverseMap();

            // Ajuste no mapeamento de Carrinho para Reeadcarrinho (incluindo o campo Status)
            CreateMap<Carrinho, Reeadcarrinho>()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status)) // Mapeia o campo Status explicitamente
                .ReverseMap();

        }
    }
}
