using Core._02_Repository;
using Core._03_Entidades;
using ctrgamer._01_service.Interfaces;
using ctrgamer._02_Repositorio.Interfaces;
using ctrgamer._03_entidades.DTO.Compra;
using System.Data.SQLite;

namespace Core._01_Services
{
    public class vendaservice:IVendaservice
    {
        public IVendarepositor repository { get; set; }
        public vendaservice(IVendarepositor vendarepositor)
        {
            repository = vendarepositor;
        }
        public void Adicionar(Venda usuario)
        {
            repository.Adicionar(usuario);
        }

        public void Remover(int id)
        {
            repository.Remover(id);
        }

        public List<Venda> Listar()
        {
            return repository.Listar();
        }
        public Venda BuscarTimePorId(int id)
        {
            return repository.BuscarPorId(id);
        }
        public List<Reavend> ListarCarrinhoDoUsuario(int usuarioId)
        {
          return repository.ListarCarrinhoDoUsuario(usuarioId);
        }

    }
}
