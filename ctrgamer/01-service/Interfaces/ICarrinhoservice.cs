using ctrgamer._03_entidades;
using ctrgamer._03_entidades.DTO.carrinho;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ctrgamer._01_service.Interfaces
{
    public interface ICarrinhoservice
    {
        void Adicionar(Carrinho carrinho);


        List<Carrinho> Listar();

        List<Reeadcarrinho> listarcarrinhodousuario(int usuarioid);

        void editar(Carrinho c);

        void Remover(int id);
        public void FinalizarCompra(int carrinhoId);
        public List<Reeadcarrinho> ObterCarrinhosFinalizadosPorUsuario(int usuarioId);



    }
}
