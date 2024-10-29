using ctrgamer._03_entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ctrgamer._01_service.Interfaces
{
    public interface IJogoservice
    {
        void Adicionar(Jogo J);


        List<Jogo> Listar();

        void editar(Jogo J);

        void Remover(int id);

    }
}
