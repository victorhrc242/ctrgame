using ctrgamer._03_entidades;
using ctrgamer._03_entidades.DTO.carrinho;
using ctrgamer._03_entidades.DTO.Compra;
using Dapper;
using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ctrgamer._02_Repositorio
{
    public class comprarepositor
    {
        private readonly string ConnectionString;
        private readonly carrinhoRepositorioi _carrrinhoreposito;
        private readonly UsuarioRepositor _usuariorepositor;
        public comprarepositor(string connectionString)
        {

            ConnectionString = connectionString;
            _carrrinhoreposito = new carrinhoRepositorioi(ConnectionString);
        _usuariorepositor=new UsuarioRepositor(ConnectionString);
        }




        public void Adicionar(Compra u)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            connection.Insert<Compra>(u);

        }



        public List<Compra> Listar()
        {
            using var connection = new SQLiteConnection(ConnectionString);
            List<Compra> list = connection.GetAll<Compra>().ToList();
            //TransformarListaCarrinhoEmCarrinhoDTO();
            return list;
        }

        private List<ReadCompraDTO> TransformarListaCarrinhoEmCarrinhoDTO(List<Compra> list)
        {
            List<ReadCompraDTO> listDTO = new List<ReadCompraDTO>();

            foreach (Compra car in list)
            {
                ReadCompraDTO readCarrinho = new ReadCompraDTO();

                // Mapeia o carrinho associado à compra
                readCarrinho.Carrinho = _carrrinhoreposito.Buscarporid(car.carrinhoid); // Certifique-se de que 'Carrinho' esteja correto no DTO
                readCarrinho.usuario = _usuariorepositor.Buscarporid(car.usuarioid);
                // Mapeia os outros campos da compra
                readCarrinho.Id = car.Id;// Id da compra
                readCarrinho.DataCompra = car.Datacompra;    // Data da compra 
                readCarrinho.MetodoPagamento = car.tipodepagamento; // Método de pagamento (ex: "PIX", "Crédito")
                readCarrinho.ValorFinal=car.ValorFinal;
                // Adiciona o DTO à lista
                listDTO.Add(readCarrinho);
            }

            return listDTO;
        }
        public List<ReadCompraDTO> ListarCarrinhoDoUsuario(int usuarioId)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            List<Compra> list = connection.Query<Compra>($"SELECT Id,Carrinhoid,usuarioid FROM Compras WHERE UsuarioId = {usuarioId}").ToList();
            List<ReadCompraDTO> listDTO = TransformarListaCarrinhoEmCarrinhoDTO(list);
            return listDTO;
        }
        public Compra Buscarporid(int id)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            return connection.Get<Compra>(id);
        }
        public void Remover(int id)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            Compra novoproduto = Buscarporid(id);
            connection.Delete<Compra>(novoproduto);
        }
        public void editar(Compra u)
        {
            using var connection = new SQLiteConnection(ConnectionString);

            connection.Update<Compra>(u);
        }
    }
}
