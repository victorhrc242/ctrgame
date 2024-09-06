using ctrgamer._02_Repositorio;
using ctrgamer._03_entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ctrgamer._01_service
{
    public class UsuarioService
    {

      UsuarioRepositor repositorio { get; set; }
        public UsuarioService(string connectionString)
        {
            repositorio=new UsuarioRepositor(connectionString);
        }
            public void Adicionar(usuario usuario)
            {
                repositorio.Adicionar(usuario);
            }

        public List<usuario> Listar()
        {
           return repositorio.listar();
        }
        public void editar( usuario usuario)
        {
            repositorio.editar( usuario);
        }
        public void Remover(int id)
        {

            repositorio.Remover(id);
        }


    }
}
