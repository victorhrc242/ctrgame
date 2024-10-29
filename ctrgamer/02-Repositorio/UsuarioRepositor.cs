using ctrgamer._02_Repositorio.Interfaces;
using ctrgamer._03_entidades;
using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ctrgamer._02_Repositorio;

public class UsuarioRepositor:IUsuariorepositor
{
    private readonly  string ConnectionString;
    public UsuarioRepositor(string connectionString)
    {

        ConnectionString=connectionString;

    }




    public void Adicionar(usuarioS u)
    {
        using var connection = new SQLiteConnection(ConnectionString);
        connection.Insert<usuarioS>(u);

    }
    public List<usuarioS> listar()
    {
        {
            using var connection = new SQLiteConnection(ConnectionString);
            {
                List<usuarioS> u = connection.GetAll<usuarioS>().ToList();
                return u;
            }
        }
    }
    public usuarioS Buscarporid(int id)
    {
        using var connection = new SQLiteConnection(ConnectionString);
        return connection.Get<usuarioS>(id);
    }
    public void Remover(int id)
    {
        using var connection = new SQLiteConnection(ConnectionString);
        usuarioS novoproduto = Buscarporid(id);
        connection.Delete<usuarioS>(novoproduto);
    }
    public void editar(usuarioS u)
    {
        using var connection = new SQLiteConnection(ConnectionString);

        connection.Update<usuarioS>(u);
    }


}


