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
            carrinho.Status = "Em andamento";  // Defina o status como "Em andamento" ao criar um novo carrinho
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

            // Aqui, vamos filtrar os carrinhos com status "Em andamento"
            List<Carrinho> list = connection.Query<Carrinho>($"SELECT Id, jogoid,  usuarioid, Status FROM carrinhos WHERE UsuarioId = {usuarioId} AND Status <> 'Finalizado'").ToList();

            List<Reeadcarrinho> listDTO = TransformarListaCarrinhoEmCarrinhoDTO(list);
            return listDTO;
        }
        public List<Reeadcarrinho> ListarCarrinhoFinalizadoDoUsuario(int usuarioId)
        {
            using var connection = new SQLiteConnection(ConnectionString);

            // Consulta para selecionar carrinhos onde o status é 'Finalizado' para o usuário específico
            var query = "SELECT Id, jogoid,  usuarioid, Status FROM carrinhos WHERE UsuarioId = @UsuarioId AND Status = 'Finalizado'";

            // Executa a consulta e mapeia para a lista de Carrinho
            var carrinhos = connection.Query<Carrinho>(query, new { UsuarioId = usuarioId }).ToList();

            // Mapeia os carrinhos para o DTO Reeadcarrinho
            var carrinhosDto = TransformarListaCarrinhoEmCarrinhoDTO(carrinhos);

            return carrinhosDto;
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
        //guarda venda  do carrinho  
        public void FinalizarCompra(int carrinhoId)
        {
            using var connection = new SQLiteConnection(ConnectionString);

            // Buscar carrinho
            Carrinho carrinho = connection.Get<Carrinho>(carrinhoId);
            if (carrinho != null)
            {
                // Alterar status para 'Finalizado'
                carrinho.Status = "Finalizado";

                // Atualizar o carrinho no banco de dados
                connection.Update<Carrinho>(carrinho);
            }
        }

    }
}
