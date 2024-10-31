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

namespace ctrgamer._02_Repositorio;

public class UsuarioRepositor:IUsuariorepositor
{
    private readonly  string ConnectionString;
    public UsuarioRepositor(IConfiguration configuration)
    {

        ConnectionString = configuration.GetConnectionString("DefaultConnection");

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


