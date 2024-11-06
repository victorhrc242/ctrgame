using ctrgamer._03_entidades.DTO.Compra;
using ctrgamer._03_entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ctrgamer._01_service.Interfaces
{
    public interface IVendaservice
    {
        public void Adicionar(Venda carrinho);

        public List<Venda> Listar();



        public List<Readvenda> ListarCarrinhoDoUsuario(int usuarioId);
        public void Remover(int id);

        public void editar(Venda c);
       
    }
}
