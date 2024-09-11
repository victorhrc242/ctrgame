using ctrgamer._02_Repositorio;
using ctrgamer._03_entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ctrgamer._01_service
{
    public class categoriaservice
    {
        categoriarepositor repositorio { get; set; }
        public categoriaservice(string connectionString)
        {

            repositorio = new categoriarepositor(connectionString);
        }
        public void Adicionar(Categoria c)
        {
            repositorio.Adicionar(c);
        }

        public List<Categoria> Listar()
        {
            return repositorio.listar();
        }
        public void editar(Categoria c)
        {
            repositorio.editar(c);
        }
        public void Remover(int id)
        {

            repositorio.Remover(id);
        }

    }
}
