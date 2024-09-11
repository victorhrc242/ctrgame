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
    public class itemcompradorepositor
    {
        private readonly string ConnectionString;
        public itemcompradorepositor(string connectionString)
        {

            ConnectionString = connectionString;

        }




        public void Adicionar(ItemCompra u)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            connection.Insert<ItemCompra>(u);

        }
        public List<ItemCompra> listar()
        {
            {
                using var connection = new SQLiteConnection(ConnectionString);
                {
                    List<ItemCompra> u = connection.GetAll<ItemCompra>().ToList();
                    return u;
                }
            }
        }
        public ItemCompra Buscarporid(int id)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            return connection.Get<ItemCompra>(id);
        }
        public void Remover(int id)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            ItemCompra novoproduto = Buscarporid(id);
            connection.Delete<ItemCompra>(novoproduto);
        }
        public void editar(ItemCompra u)
        {
            using var connection = new SQLiteConnection(ConnectionString);

            connection.Update<ItemCompra>(u);
        }
    }
}
