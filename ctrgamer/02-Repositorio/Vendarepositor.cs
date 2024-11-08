using Core._03_Entidades;
using ctrgamer._02_Repositorio;
using ctrgamer._02_Repositorio.Interfaces;
using ctrgamer._03_entidades.DTO.Compra;
using Dapper;
using Dapper.Contrib.Extensions;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core._02_Repository
{
    public class Vendarepositor:IVendarepositor
    {
        private readonly string ConnectionString;
        private readonly ICarrinhorepositor Carrinhorepositor;
        public Vendarepositor(IConfiguration config,ICarrinhorepositor carrinhorepositor)
        {
            string _config = config.GetConnectionString("DefaultConnection");
            Carrinhorepositor = carrinhorepositor;
        }
        public void Adicionar(Venda venda)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            connection.Insert<Venda>(venda);
        }
        public void Remover(int id)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            Venda usuario = BuscarPorId(id);
            connection.Delete<Venda>(usuario);
        }
        public List<Venda> Listar()
        {
            using var connection = new SQLiteConnection(ConnectionString);
            return connection.GetAll<Venda>().ToList();
        }
        public Venda BuscarPorId(int id)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            return connection.Get<Venda>(id);
        }
        private List<Reavend> TransformarListaCarrinhoEmCarrinhoDTO(List<Venda> list)
        {
            List<Reavend> listDTO = new List<Reavend>();

            foreach (Venda car in list)
            {
                Reavend readCarrinho = new Reavend();
                readCarrinho.carrinho = Carrinhorepositor.Buscarporid(car.id);
                listDTO.Add(readCarrinho);
            }
            return listDTO;
        }
        public List<Reavend> ListarCarrinhoDoUsuario(int usuarioId)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            List<Venda> list = connection.Query<Venda>($"SELECT Id, carrinhoid, Metododepagamento,ValorFinal FROM Vendas WHERE UsuarioId = {usuarioId}").ToList();
            List<Reavend> listDTO = TransformarListaCarrinhoEmCarrinhoDTO(list);
            return listDTO;
        }
    }
}
