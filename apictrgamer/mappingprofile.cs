using AutoMapper;
using ctrgamer._03_entidades;
using ctrgamer._03_entidades.DTO.carrinho;
using ctrgamer._03_entidades.DTO.Categorias;
using ctrgamer._03_entidades.DTO.Compra;
namespace apictrgamer
{
    public class mappingprofile:Profile
    {
        public mappingprofile()
        {
            CreateMap<ReadCategoria, JogoCategoria>().ReverseMap();
            CreateMap<Reeadcarrinho, Carrinho>().ReverseMap();
            CreateMap<Venda, Readvenda>().ReverseMap();
     

        }
    }
}
