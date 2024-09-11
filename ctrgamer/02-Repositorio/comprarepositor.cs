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
    public class comprarepositor
    {
        private readonly string ConnectionString;
        public comprarepositor(string connectionString)
        {

            ConnectionString = connectionString;

        }




        public void Adicionar(Compra u)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            connection.Insert<Compra>(u);

        }
        public List<Compra> listar()
        {
            {
                using var connection = new SQLiteConnection(ConnectionString);
                {
                    List<Compra> u = connection.GetAll<Compra>().ToList();
                    return u;
                }
            }
        }
        public Compra Buscarporid(int id)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            return connection.Get<Compra>(id);
        }
        public void Remover(int id)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            Compra novoproduto = Buscarporid(id);
            connection.Delete<Compra>(novoproduto);
        }
        public void editar(Compra u)
        {
            using var connection = new SQLiteConnection(ConnectionString);

            connection.Update<Compra>(u);
        }
    }
}
