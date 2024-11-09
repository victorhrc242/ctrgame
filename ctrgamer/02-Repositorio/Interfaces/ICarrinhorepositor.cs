using ctrgamer._03_entidades;
using ctrgamer._03_entidades.DTO.carrinho;
using Dapper;
using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public void FinalizarCompra(int carrinhoId);
        public List<Reeadcarrinho> ListarCarrinhoFinalizadoDoUsuario(int usuarioId);
       
    }
}
