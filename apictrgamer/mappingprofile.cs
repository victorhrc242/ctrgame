using AutoMapper;
using ctrgamer._03_entidades;
using ctrgamer._03_entidades.DTO.carrinho;
using ctrgamer._03_entidades.DTO.jogo;
using ctrgamer._03_entidades.DTO.usuario;

namespace apictrgamer
{
    public class mappingprofile:Profile
    {
        public mappingprofile()
        {
            CreateMap<createusuario, usuario>().ReverseMap();
            CreateMap<createjogo, Jogo>().ReverseMap();
            CreateMap<Reeadcarrinho, Carrinho>().ReverseMap();
        }
    }
}
