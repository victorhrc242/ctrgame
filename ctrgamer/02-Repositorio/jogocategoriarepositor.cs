using ctrgamer._02_Repositorio.Interfaces;
using ctrgamer._03_entidades;
using ctrgamer._03_entidades.DTO.Categorias;
using Dapper;
using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ctrgamer._02_Repositorio
{
    public class jogocategoriarepositor:IJogocategoriaRepositor
    {
        private readonly string ConnectionString;
        private readonly IJogosReposytor _jogorepositorio;
        private readonly ICategoriaReposytor _categoriarepositor;
        public jogocategoriarepositor(string connectionString)
        {

            ConnectionString = connectionString;
        _jogorepositorio=new Jogorepositorio(ConnectionString);
            _categoriarepositor = new categoriarepositor(ConnectionString);

        }
        public void Adicionar(JogoCategoria u)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            connection.Insert<JogoCategoria>(u);

        }
        public List<JogoCategoria> Listar()
        {
            using var connection = new SQLiteConnection(ConnectionString);
            List<JogoCategoria> list = connection.GetAll<JogoCategoria>().ToList();
            //TransformarListaCarrinhoEmCarrinhoDTO(list);
            return list;
        }
        private List<ReadCategoria> TransformarListaCarrinhoEmCarrinhoDTO(List<JogoCategoria> list)
        {
            List<ReadCategoria> listDTO = new List<ReadCategoria>();

            foreach (JogoCategoria car in list)
            {
               ReadCategoria categoria = new ReadCategoria();
                categoria.jogo = _jogorepositorio.Buscarporid(car.jogoid);
                categoria.categoria = _categoriarepositor.Buscarporid(car.categoriaid);
                listDTO.Add(categoria);
            }
            return listDTO;
        }
        public List<ReadCategoria> ListarJogoPorCategoria(int categoriaId)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            List<JogoCategoria> list = connection.Query<JogoCategoria>(
                $"SELECT jogoid, categoriaid FROM jogoCategorias WHERE CategoriaId = {categoriaId}"
            ).ToList();
            List<ReadCategoria> listDTO = TransformarListaCarrinhoEmCarrinhoDTO(list);

            return listDTO;
        }

        public JogoCategoria Buscarporid(int id)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            return connection.Get<JogoCategoria>(id);
        }
        public void Remover(int id)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            JogoCategoria novoproduto = Buscarporid(id);
            connection.Delete<JogoCategoria>(novoproduto);
        }
        public void editar(JogoCategoria u)
        {
            using var connection = new SQLiteConnection(ConnectionString);

            connection.Update<JogoCategoria>(u);
        }
    }
}
