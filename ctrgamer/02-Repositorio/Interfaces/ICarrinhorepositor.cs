using ctrgamer._03_entidades;
using ctrgamer._03_entidades.DTO.carrinho;

namespace ctrgamer._02_Repositorio.Interfaces
{
    public interface ICarrinhorepositor
    {
        public void Adicionar(Carrinho carrinho);
        public List<Carrinho> Listar();
        public List<Reeadcarrinho> ListarCarrinhoDoUsuario(int usuarioId);
        public Carrinho Buscarporid(int id);
        public void Remover(int id);
        public void editar(Carrinho c);
    }
}
