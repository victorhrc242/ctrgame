using AutoMapper;
using ctrgamer._03_entidades;
using ctrgamer._03_entidades.DTO.carrinho;
using ctrgamer._03_entidades.DTO.jogo;

namespace apictrgamer
{
    public class mappingprofile:Profile
    {
        public mappingprofile()
        {
            CreateMap<createjogo, Jogo>().ReverseMap();
            CreateMap<Reeadcarrinho, Carrinho>().ReverseMap();
        }
    }
}
