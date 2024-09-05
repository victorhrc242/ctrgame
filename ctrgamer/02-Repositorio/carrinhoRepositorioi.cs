using ctrgamer._03_entidades;
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
    public class carrinhoRepositorioi
    {
        private  readonly  string ConnectionString;
        public  carrinhoRepositorioi ( string  connectionString)
        {

            ConnectionString = connectionString;

        }

        


        public void Adicionar(Carrinho c)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            connection.Insert<Carrinho>(c);

        }
        public   List<Carrinho> listar()
        {
            {
                using var connection = new SQLiteConnection(ConnectionString);
                {
                    List<Carrinho> c = connection.GetAll<Carrinho>().ToList();
                    return c;
                }
            }
        }
        public Carrinho Buscarporid(int id)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            return connection.Get<Carrinho>(id);
        }
        public void Remover(int id)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            Carrinho novoproduto = Buscarporid(id);
            connection.Delete<Carrinho>(novoproduto);
        }
        public void editar(Carrinho c)
        {
            using var connection = new SQLiteConnection(ConnectionString);

            connection.Update<Carrinho>(c);
        }
    }
}
