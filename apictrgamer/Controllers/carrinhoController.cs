using ctrgamer._01_service;
using ctrgamer._03_entidades;
using Microsoft.AspNetCore.Mvc;

namespace apictrgamer.Controllers;

public class carrinhoController : ControllerBase
{
    carrinhoService service;
    public carrinhoController()
    {
        service = new carrinhoService();

    }

    [HttpPost("adicionar-carrinho")]
    public void adicionaraluno(Carrinho u)
    {
        service.Adicionar(u);
    }

    [HttpGet("Listar-compras")]
    public List<Carrinho> listar()
    {



        return service.Listar();
    }
    [HttpDelete("Remover-compras")]
    public void Removeracompra(int id)
    {
        service.Remover(id);
    }
    [HttpPut("editar-compra")]
    public void editarcompra(int id, Carrinho carrinho)
    {
        service.editar(id, carrinho);
    }
}
