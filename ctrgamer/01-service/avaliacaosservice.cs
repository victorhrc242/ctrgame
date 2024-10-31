using ctrgamer._01_service.Interfaces;
using ctrgamer._02_Repositorio;
using ctrgamer._02_Repositorio.Interfaces;
using ctrgamer._03_entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ctrgamer._01_service
{
    public class avaliacaosservice:IAvaliacaoservice
    {
        private readonly IAvaliacaoReposytor repositorio;
        public avaliacaosservice(IAvaliacaoReposytor avaliacaoReposytor)
        {
            repositorio = avaliacaoReposytor;
        }
        public void Adicionar(Avaliacao a)
        {
            repositorio.Adicionar(a);
        }

        public List<Avaliacao> Listar()
        {
            return repositorio.listar();
        }
        public void editar(Avaliacao a)
        {
            repositorio.editar(a);
        }
        public void Remover(int id)
        {

            repositorio.Remover(id);
        }

    }
}
