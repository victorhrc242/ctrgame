using ctrgamer._02_Repositorio.Interfaces;
using ctrgamer._03_entidades;
using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ctrgamer._02_Repositorio
{
    public class categoriarepositor: ICategoriaReposytor
    {
        private readonly string ConnectionString;
        public categoriarepositor(string connectionString)
        {

            ConnectionString = connectionString;

        }




        public void Adicionar(Categoria u)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            connection.Insert<Categoria>(u);

        }
        public List<Categoria> listar()
        {
            {
                using var connection = new SQLiteConnection(ConnectionString);
                {
                    List<Categoria> u = connection.GetAll<Categoria>().ToList();
                    return u;
                }
            }
        }
        public Categoria Buscarporid(int id)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            return connection.Get<Categoria>(id);
        }
        public void Remover(int id)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            Categoria novoproduto = Buscarporid(id);
            connection.Delete<Categoria>(novoproduto);
        }
        public void editar(Categoria u)
        {
            using var connection = new SQLiteConnection(ConnectionString);

            connection.Update<Categoria>(u);
        }
    }
}
