using ctrgamer._03_entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ctrgamer._01_service.Interfaces
{
    public interface Icategoriasservice
    {
        void Adicionar(Categoria c);


        List<Categoria> Listar();

        void editar(Categoria c);

        void Remover(int id);
    
    }
}
