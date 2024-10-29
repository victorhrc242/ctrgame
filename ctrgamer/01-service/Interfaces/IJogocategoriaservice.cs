using ctrgamer._03_entidades.DTO.Categorias;
using ctrgamer._03_entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ctrgamer._01_service.Interfaces
{
    public interface IJogocategoriaservice
    {
        void Adicionar(JogoCategoria j);


        List<JogoCategoria> Listar();


        List<ReadCategoria> ListarJogoPorCategoria(int categoriaId);

        void editar(JogoCategoria j);

        void Remover(int id);
  

    }
}
