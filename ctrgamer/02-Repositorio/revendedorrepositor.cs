using ctrgamer._02_Repositorio.Interfaces;
using ctrgamer._03_entidades;
using Dapper.Contrib.Extensions;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ctrgamer._02_Repositorio
{
    public class revendedorrepositor:IRevendedorRepositor
    {
        private readonly string ConnectionString;
        public revendedorrepositor(IConfiguration configuration)
        {

            ConnectionString = configuration.GetConnectionString("DefaultConnection");

        }
        public void Adicionar(Revendedore r)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            connection.Insert<Revendedore>(r);

        }
        public List<Revendedore> listar()
        {
            {
                using var connection = new SQLiteConnection(ConnectionString);
                {
                    List<Revendedore> u = connection.GetAll<Revendedore>().ToList();
                    return u;
                }
            }
        }
        public Revendedore Buscarporid(int id)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            return connection.Get<Revendedore>(id);
        }
        public void Remover(int id)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            Revendedore novoproduto = Buscarporid(id);
            connection.Delete<Revendedore>(novoproduto);
        }
        public void editar(Revendedore r)
        {
            using var connection = new SQLiteConnection(ConnectionString);

            connection.Update<Revendedore>(r);
        }
    }
}
