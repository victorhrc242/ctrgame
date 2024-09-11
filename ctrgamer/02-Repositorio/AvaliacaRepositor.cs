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
    public class AvaliacaRepositor
    {
        private readonly string ConnectionString;
        public AvaliacaRepositor(string connectionString)
        {

            ConnectionString = connectionString;

        }




        public void Adicionar(Avaliacao u)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            connection.Insert<Avaliacao>(u);

        }
        public List<Avaliacao> listar()
        {
            {
                using var connection = new SQLiteConnection(ConnectionString);
                {
                    List<Avaliacao> u = connection.GetAll<Avaliacao>().ToList();
                    return u;
                }
            }
        }
        public Avaliacao Buscarporid(int id)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            return connection.Get<Avaliacao>(id);
        }
        public void Remover(int id)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            Avaliacao novoproduto = Buscarporid(id);
            connection.Delete<Avaliacao>(novoproduto);
        }
        public void editar(Avaliacao u)
        {
            using var connection = new SQLiteConnection(ConnectionString);

            connection.Update<Avaliacao>(u);
        }
    }
}
