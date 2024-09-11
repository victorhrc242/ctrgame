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
    public class pagamentorepositor
    {
        private readonly string ConnectionString;
        public pagamentorepositor(string connectionString)
        {

            ConnectionString = connectionString;

        }




        public void Adicionar(Pagamento p)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            connection.Insert<Pagamento>(p);

        }
        public List<Pagamento> listar()
        {
            {
                using var connection = new SQLiteConnection(ConnectionString);
                {
                    List<Pagamento> u = connection.GetAll<Pagamento>().ToList();
                    return u;
                }
            }
        }
        public Pagamento Buscarporid(int id)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            return connection.Get<Pagamento>(id);
        }
        public void Remover(int id)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            Pagamento novoproduto = Buscarporid(id);
            connection.Delete<Pagamento>(novoproduto);
        }
        public void editar(Pagamento u)
        {
            using var connection = new SQLiteConnection(ConnectionString);

            connection.Update<Pagamento>(u);
        }
    }
}
