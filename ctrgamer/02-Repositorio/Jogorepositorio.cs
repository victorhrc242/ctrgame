using ctrgamer._02_Repositorio.Interfaces;
using ctrgamer._03_entidades;
using Dapper.Contrib.Extensions;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Configuration.Internal;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ctrgamer._02_Repositorio;

public class Jogorepositorio:IJogosReposytor
{
    private readonly  string ConnectionString;

    public Jogorepositorio(IConfiguration configuration)
    {
       ConnectionString = configuration.GetConnectionString("DefaultConnection");
    }
    public void Adicionar(Jogo J)
    {
        using var connection = new SQLiteConnection(ConnectionString);
        connection.Insert<Jogo>(J);
    }
    public List<Jogo> listar()
    {
            using var connection = new SQLiteConnection(ConnectionString);
            return connection.GetAll<Jogo>().ToList();
    }
    public Jogo Buscarporid(int id)
    {
        using var connection = new SQLiteConnection(ConnectionString);
        return connection.Get<Jogo>(id);
    }
    public void Remover(int id)
    {
        using var connection = new SQLiteConnection(ConnectionString);
        Jogo novoproduto = Buscarporid(id);
        connection.Delete<Jogo>(novoproduto);
    }
    public void editar(Jogo J)
    {
        using var connection = new SQLiteConnection(ConnectionString);
        connection.Update<Jogo>(J);
    }
}

