using Core._03_Entidades;
using ctrgamer._03_entidades.DTO.Compra;
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
        public void Adicionar(Venda venda);

        public void Remover(int id);

        public List<Venda> Listar();

        public Venda BuscarPorId(int id);


        public List<Reavend> ListarCarrinhoDoUsuario(int usuarioId);
  
    }
}
