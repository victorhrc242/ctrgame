using ctrgamer._02_Repositorio.Interfaces;
using ctrgamer._03_entidades.DTO.Compra;
using ctrgamer._03_entidades;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ctrgamer._01_service.Interfaces;
using Microsoft.Extensions.Configuration;

namespace ctrgamer._01_service
{
    public class Vendasrevice:IVendaservice
    {
        private readonly IVendarepositor vendareposito;
        public Vendasrevice(IConfiguration configuration ,IVendarepositor vendarepositor)
        {
            vendareposito= vendarepositor;
        }
        public void Adicionar(Venda carrinho)
        {
          vendareposito.Adicionar(carrinho);
        }
        public List<Venda> Listar()
        {
         return vendareposito.Listar();
        }

        
        public List<Readvenda> ListarCarrinhoDoUsuario(int usuarioId)
        {
            return vendareposito.ListarCarrinhoDoUsuario(usuarioId);
        }
        public void Remover(int id)
        {
            vendareposito.Remover(id);
        }
        public void editar(Venda c)
        {
         vendareposito.editar(c);
        }
    }
}
