using ctrgamer._03_entidades.DTO.Compra;
using ctrgamer._03_entidades;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ctrgamer._02_Repositorio.Interfaces
{
    public interface IVendarepositor
    {
        public void Adicionar(Venda carrinho);

        public List<Venda> Listar();
        public List<ReadvendaDTO> ListarCarrinhoDoUsuario(int usuarioId);

        public Venda Buscarporid(int id);

        public void Remover(int id);

        public void editar(Venda c);
       
    }
}
