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
        void Adicionar(Reevendedor r);

        List<Reevendedor> listar();

        Reevendedor Buscarporid(int id);

        void Remover(int id);

        void editar(Reevendedor r);
     
    }
}
