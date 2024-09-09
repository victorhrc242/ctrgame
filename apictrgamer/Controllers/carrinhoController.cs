using AutoMapper;
using ctrgamer._01_service;
using ctrgamer._03_entidades;
using ctrgamer._03_entidades.DTO.carrinho;
using Microsoft.AspNetCore.Mvc;

namespace apictrgamer.Controllers;

public class carrinhoController : ControllerBase
{
    private readonly carrinhoService service;
    private readonly IMapper mapper;
    public carrinhoController(IMapper _mapper, IConfiguration conficuration)
    {
        string connectionstring = conficuration.GetConnectionString("DefaultConnection");
        service = new carrinhoService(connectionstring);
        _mapper=mapper;
    }

    [HttpPost("adicionar-carrinho")]
    public void adicionaraluno(Createcarrinho c)
    {
        Carrinho carrinho= mapper.Map<Carrinho>(c);
       service.Adicionar(carrinho);

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
