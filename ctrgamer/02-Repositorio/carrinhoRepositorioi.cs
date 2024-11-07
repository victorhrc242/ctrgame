using AutoMapper;
using ctrgamer._02_Repositorio.Interfaces;
using ctrgamer._03_entidades;
using ctrgamer._03_entidades.DTO.carrinho;
using Dapper;
using Dapper.Contrib.Extensions;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Configuration;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ctrgamer._02_Repositorio
{
    public class carrinhoRepositorioi:ICarrinhorepositor
    {
        private  readonly  string ConnectionString;
        private readonly IMapper _mapper;
        private readonly IJogosReposytor _reposytoryjogo;
        private readonly IUsuariorepositor _repositoryusuario;
        public  carrinhoRepositorioi ( IConfiguration configuration,IJogosReposytor jogosReposytor,IUsuariorepositor usuariorepositor)
        {

            ConnectionString = configuration.GetConnectionString("DefaultConnection");
            _reposytoryjogo = jogosReposytor;
            _repositoryusuario = usuariorepositor;

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
                readCarrinho.jogo = _reposytoryjogo.Buscarporid(car.carrinhoid);
                listDTO.Add(readCarrinho);
            }
            return listDTO;
        }
        public List<Reeadcarrinho> ListarCarrinhoDoUsuario(int usuarioId)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            List<Carrinho> list = connection.Query<Carrinho>($"SELECT Id, jogoid, usuarioid FROM carrinhos WHERE UsuarioId = {usuarioId}").ToList();
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
