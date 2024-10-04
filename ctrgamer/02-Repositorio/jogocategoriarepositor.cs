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
    public class jogocategoriarepositor
    {
        private readonly string ConnectionString;
        public jogocategoriarepositor(string connectionString)
        {

            ConnectionString = connectionString;

        }
        public void Adicionar(JogoCategoria u)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            connection.Insert<JogoCategoria>(u);

        }
        public List<JogoCategoria> listar()
        {
            {
                using var connection = new SQLiteConnection(ConnectionString);
                {
                    List<JogoCategoria> u = connection.GetAll<JogoCategoria>().ToList();
                    return u;
                }
            }
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
