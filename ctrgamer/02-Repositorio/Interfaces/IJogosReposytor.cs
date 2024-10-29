using ctrgamer._03_entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ctrgamer._02_Repositorio.Interfaces
{
    public interface IJogosReposytor
    {
        void Adicionar(Jogo u);
        List<Jogo> listar();
        Jogo Buscarporid(int id);
        void Remover(int id);
        void editar(Jogo u);
    }
}
