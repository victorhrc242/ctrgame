using ctrgamer._03_entidades.DTO.Categorias;
using ctrgamer._03_entidades;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ctrgamer._02_Repositorio.Interfaces
{
    public interface IJogocategoriaRepositor
    {
        public void Adicionar(JogoCategoria u);
        public List<JogoCategoria> Listar();
        public List<ReadCategoria> ListarJogoPorCategoria(int categoriaId);
        public JogoCategoria Buscarporid(int id);
        public void Remover(int id);
        public void editar(JogoCategoria u);
    }
}
