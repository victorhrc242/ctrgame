using ctrgamer._02_Repositorio;
using ctrgamer._03_entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ctrgamer._01_service
{
    public class pagamentoservice
    {
        pagamentorepositor repositorio { get; set; }
        public pagamentoservice(string connectionString)
        {
            repositorio = new pagamentorepositor(connectionString);
        }
        public void Adicionar(Pagamento p)
        {
            repositorio.Adicionar(p);
        }

        public List<Pagamento> Listar()
        {
            return repositorio.listar();
        }
        public void editar(Pagamento p)
        {
            repositorio.editar(p);
        }
        public void Remover(int id)
        {

            repositorio.Remover(id);
        }

    }
}
