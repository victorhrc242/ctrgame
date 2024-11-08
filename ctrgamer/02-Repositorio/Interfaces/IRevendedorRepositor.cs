using ctrgamer._03_entidades;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ctrgamer._02_Repositorio.Interfaces
{
    public interface IRevendedorRepositor
    {
        void Adicionar(Revendedore r);

        List<Revendedore> listar();

        Revendedore Buscarporid(int id);

        void Remover(int id);

        void editar(Revendedore r);
     
    }
}
