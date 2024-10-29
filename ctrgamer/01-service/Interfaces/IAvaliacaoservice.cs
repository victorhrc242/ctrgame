using ctrgamer._03_entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ctrgamer._01_service.Interfaces
{
    public interface IAvaliacaoservice
    {
        void Adicionar(Avaliacao a);


        List<Avaliacao> Listar();

        void editar(Avaliacao a);

        void Remover(int id);
     

    }
}
