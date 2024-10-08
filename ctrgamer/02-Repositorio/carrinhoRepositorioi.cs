﻿using AutoMapper;
using ctrgamer._03_entidades;
using ctrgamer._03_entidades.DTO.carrinho;
using Dapper;
using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ctrgamer._02_Repositorio
{
    public class carrinhoRepositorioi
    {
        private  readonly  string ConnectionString;
        private readonly IMapper _mapper;
        private readonly Jogorepositorio _reposytoryjogo;
        private readonly UsuarioRepositor _repositoryusuario;
        public  carrinhoRepositorioi ( string  connectionString)
        {

            ConnectionString = connectionString;
           _reposytoryjogo = new Jogorepositorio(connectionString);
            _repositoryusuario = new UsuarioRepositor(connectionString);

        }
        public void Adicionar(Carrinho carrinho)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            connection.Insert<Carrinho>(carrinho);
        }
        public List<Carrinho> Listar()
        {
            using var connection = new SQLiteConnection(ConnectionString);
            List<Carrinho> list = connection.GetAll<Carrinho>().ToList();
            //TransformarListaCarrinhoEmCarrinhoDTO();
            return list;
        }

        private List<Reeadcarrinho> TransformarListaCarrinhoEmCarrinhoDTO(List<Carrinho> list)
        {
            List<Reeadcarrinho> listDTO = new List<Reeadcarrinho>();

            foreach (Carrinho car in list)
            {
                Reeadcarrinho readCarrinho = new Reeadcarrinho();
                readCarrinho.usuario = _repositoryusuario.Buscarporid(car.usuarioid);
                readCarrinho.jogo = _reposytoryjogo.Buscarporid(car.JogoId);
                listDTO.Add(readCarrinho);
            }
            return listDTO;
        }
        public List<Reeadcarrinho> ListarCarrinhoDoUsuario(int usuarioId)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            List<Carrinho> list = connection.Query<Carrinho>($"SELECT Id, jogoid,pagamentoid, usuarioid FROM carrinhos WHERE UsuarioId = {usuarioId}").ToList();
            List<Reeadcarrinho> listDTO = TransformarListaCarrinhoEmCarrinhoDTO(list);
            return listDTO;
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
