using ctrgamer._01_service;
using ctrgamer._03_entidades;
using Microsoft.AspNetCore.Mvc;

namespace apictrgamer.Controllers;

public class carrinhoController : ControllerBase
{
    private readonly carrinhoService service;
    public carrinhoController(IConfiguration conficuration)
    {
        string connectionstring = conficuration.GetConnectionString("DefaultConnection");
        service = new carrinhoService(connectionstring);

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
    public void editarcompra(Carrinho c)
    {
        service.editar(c);
    }
}
