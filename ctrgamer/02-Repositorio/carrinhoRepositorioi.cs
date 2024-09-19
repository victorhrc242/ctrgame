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
        private readonly jogocategoriarepositor _reposytoryjogo;
        private readonly UsuarioRepositor _repositoryusuario;
        private readonly pagamentorepositor _pagamentorepository;
        public  carrinhoRepositorioi ( string  connectionString,IMapper mapper)
        {

            ConnectionString = connectionString;
            _mapper= mapper;
           _reposytoryjogo = new jogocategoriarepositor(connectionString);
            _repositoryusuario = new UsuarioRepositor(connectionString);
            _reposytoryjogo = new jogocategoriarepositor(connectionString);

        }

        


        public void Adicionar(Carrinho c)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            connection.Insert<Carrinho>(c);

        }
        public   List<Carrinho> listar()
        {
            {
                using var connection = new SQLiteConnection(ConnectionString);
                {
                    List<Carrinho> c = connection.GetAll<Carrinho>().ToList();
                    List<Reeadcarrinho> carrinhodto = new List<Reeadcarrinho>();
                    foreach (Carrinho r in c)
                    {
                        Reeadcarrinho carrinhodto = new Reeadcarrinho();
                        carrinhodtos.usuario = r.usuarioid;
                        carrinhodtos.usuario = r.usuarioid;
                        rotinaDTO.Dia = _repositoryDia.BuscarPorID(r.DiaId);
                        rotinaDTO.PessoaId = r.PessoaId;
                        rotinaDTO.Pessoa = _repositoryPessoa.BuscarPorId(r.PessoaId);
                        rotinaDTO.Atividade = _repositoryAtividade.BuscarPorId(r.AtividadeId);
                        rotinasDTO.Add(rotinaDTO);
                    }
                    return c;
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
