using AutoMapper;
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
        private readonly pagamentorepositor _pagamentorepository;
        public  carrinhoRepositorioi ( string  connectionString,IMapper mapper)
        {

            ConnectionString = connectionString;
            _mapper= mapper;
           _reposytoryjogo = new Jogorepositorio(connectionString);
            _repositoryusuario = new UsuarioRepositor(connectionString);
           _pagamentorepository=new pagamentorepositor(connectionString);

        }
        public void Adicionar(Carrinho c)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            connection.Insert<Carrinho>(c);

        }
        public   List<Reeadcarrinho> listar()
        {
            {
                using var connection = new SQLiteConnection(ConnectionString);
                {
                    List<Carrinho> c = connection.GetAll<Carrinho>().ToList();
                    List<Reeadcarrinho> carrinhodtos = new List<Reeadcarrinho>();
                    foreach (Carrinho r in c)
                    {
                        Reeadcarrinho carrinhodto = new Reeadcarrinho();
                        carrinhodto.ID = r.ID;
                        carrinhodto.usuario = _repositoryusuario.Buscarporid(r.usuarioid);
                        carrinhodto.jogo = _reposytoryjogo.Buscarporid(r.JogoId);
                        carrinhodto.pagamento = _pagamentorepository.Buscarporid(r.pagamentoid);
                        carrinhodtos.Add(carrinhodto);
                     
                    }
                    return carrinhodtos;
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
