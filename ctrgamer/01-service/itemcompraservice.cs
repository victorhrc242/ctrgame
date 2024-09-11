using ctrgamer._02_Repositorio;
using ctrgamer._03_entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ctrgamer._01_service
{
    public class itemcompraservice
    {
        itemcompradorepositor repositorio { get; set; }
        public itemcompraservice(string connectionString)
        {
            repositorio = new itemcompradorepositor(connectionString);
        }
        public void Adicionar(ItemCompra i)
        {
            repositorio.Adicionar(i);
        }

        public List<ItemCompra> Listar()
        {
            return repositorio.listar();
        }
        public void editar(ItemCompra i)
        {
            repositorio.editar(i);
        }
        public void Remover(int id)
        {

            repositorio.Remover(id);
        }

    }
}
