using ctrgamer._03_entidades;
using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ctrgamer._02_Repositorio;

public class UsuarioRepositor
{
    private readonly  string ConnectionString;
    public UsuarioRepositor(string connectionString)
    {

        ConnectionString=connectionString;

    }




    public void Adicionar(usuario u)
    {
        using var connection = new SQLiteConnection(ConnectionString);
        connection.Insert<usuario>(u);

    }
    public List<usuario> listar()
    {
        {
            using var connection = new SQLiteConnection(ConnectionString);
            {
                List<usuario> u = connection.GetAll<usuario>().ToList();
                return u;
            }
        }
    }
    public usuario Buscarporid(int id)
    {
        using var connection = new SQLiteConnection(ConnectionString);
        return connection.Get<usuario>(id);
    }
    public void Remover(int id)
    {
        using var connection = new SQLiteConnection(ConnectionString);
        usuario novoproduto = Buscarporid(id);
        connection.Delete<usuario>(novoproduto);
    }
    public void editar(usuario u)
    {
        using var connection = new SQLiteConnection(ConnectionString);

        connection.Update<usuario>(u);
    }
}


