﻿using ctrgamer._02_Repositorio.Interfaces;
using Dapper;
using Dapper.Contrib.Extensions;
using Microsoft.Extensions.Configuration;
using System.Data.SQLite;

namespace ctrgamer._03_entidades.DTO.Compra;
public class VendaReposytor:IVendarepositor
{
    private readonly string ConnectionString;
    private readonly IUsuariorepositor usuariorepositor1;
    private readonly ICarrinhorepositor carrinhorepositor1;
    public VendaReposytor(IConfiguration configuration,IUsuariorepositor usuariorepositor,ICarrinhorepositor carrinhorepositor)
    {
        ConnectionString = configuration.GetConnectionString("DefaultConnection");
        usuariorepositor1= usuariorepositor;
        carrinhorepositor1= carrinhorepositor;
    }
    public void Adicionar(Venda carrinho)
    {
        using var connection = new SQLiteConnection(ConnectionString);
        connection.Insert<Venda>(carrinho);
    }
    public List<Venda> Listar()
    {
        using var connection = new SQLiteConnection(ConnectionString);
        List<Venda> list = connection.GetAll<Venda>().ToList();
        //TransformarListaCarrinhoEmCarrinhoDTO();
        return list;
    }

    private List<Readvenda> TransformarListaCarrinhoEmCarrinhoDTO(List<Venda> list)
    {
        List<Readvenda> listDTO = new List<Readvenda>();

        foreach (Venda car in list)
        {
            Readvenda readCarrinho = new Readvenda();
            readCarrinho.usuario = usuariorepositor1.Buscarporid(car.usuarioid);
            readCarrinho.carrinho= carrinhorepositor1.Buscarporid(car.);
            listDTO.Add(readCarrinho);
        }
        return listDTO;
    }
    public List<Readvenda> ListarCarrinhoDoUsuario(int usuarioId)
    {
        using var connection = new SQLiteConnection(ConnectionString);
        List<Venda> list = connection.Query<Venda>($"SELECT Id, Usuarioid,data_de_compra, carrinhoid FROM Vendas WHERE UsuarioId = {usuarioId}").ToList();
        List<Readvenda> listDTO = TransformarListaCarrinhoEmCarrinhoDTO(list);
        return listDTO;
    }
    public Venda Buscarporid(int id)
    {
        using var connection = new SQLiteConnection(ConnectionString);
        return connection.Get<Venda>(id);
    }
    public void Remover(int id)
    {
        using var connection = new SQLiteConnection(ConnectionString);
        Venda novoproduto = Buscarporid(id);
        connection.Delete<Venda>(novoproduto);
    }
    public void editar(Venda c)
    {
        using var connection = new SQLiteConnection(ConnectionString);

        connection.Update<Venda>(c);
    }
}