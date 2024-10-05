using ctrgamer._02_Repositorio;
using ctrgamer._03_entidades;
using ctrgamer._03_entidades.DTO.Compra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ctrgamer._01_service
{
    public class compraservice
    {
        comprarepositor repositorio { get; set; }
        public compraservice(string connectionString)
        {
            repositorio = new comprarepositor(connectionString);
        }
        public void Adicionar(Compra c)
        {
            repositorio.Adicionar(c);
        }

        public List<Compra> Listar()
        {
            return repositorio.Listar();
        }
        public List<ReadCompraDTO> listarcompradto(int usuarioid)
        {
            return repositorio.ListarCarrinhoDoUsuario(usuarioid);
        }
        public void editar(Compra c)
        {
            repositorio.editar(c);
        }
        public void Remover(int id)
        {

            repositorio.Remover(id);
        }
    }
}
