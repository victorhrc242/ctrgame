using ctrgamer._03_entidades;
using ctrgamer._03_entidades.DTO.Compra;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ctrgamer._02_Repositorio.Interfaces
{
    public interface IComprarepositor
    {
        public void Adicionar(Compra u);
        public List<Compra> Listar();
        public List<ReadCompraDTO> ListarCarrinhoDoUsuario(int usuarioId);
        public Compra Buscarporid(int id);
        public void Remover(int id);
        public void editar(Compra u);

    }
}
