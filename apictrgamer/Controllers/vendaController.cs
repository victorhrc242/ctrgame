using ctrgamer._03_entidades.DTO.Compra;
using ctrgamer._03_entidades;
using ctrgamer._01_service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace apictrgamer.Controllers
{
    
    public class vendacontroller
    {
        private readonly IVendaservice vendasevice;
        public vendacontroller(IVendaservice vendaservice,IConfiguration configuration)
        {
            vendasevice = vendaservice;
        }
        [HttpPost("adicinar-venda")]
        public void Adicionar(Venda carrinho)
        {
            vendasevice.Adicionar(carrinho);
        }
        [HttpGet("listar-venda")]
        public List<Venda> Listar()
        {
            return vendasevice.Listar();
        }

        [HttpGet("listar-venda-por-usuario")]
        public List<Readvenda> ListarCarrinhoDoUsuario(int usuarioId)
        {
            return vendasevice.ListarCarrinhoDoUsuario(usuarioId);
        }
        [HttpDelete("deleta-venda")]
        public void Remover(int id)
        {
            vendasevice.Remover(id);
        }
        [HttpPut("editar-venda")]
        public void editar(Venda c)
        {
            vendasevice.editar(c);
        }
    }
}
