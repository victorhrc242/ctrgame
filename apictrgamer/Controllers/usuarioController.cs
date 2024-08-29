using ctrgamer._01_service;
using ctrgamer._03_entidades;
using Microsoft.AspNetCore.Mvc;

namespace apictrgamer.Controllers;
[ApiController]
[Route("[controller]")]
public class usuarioController :ControllerBase
{

    UsuarioService service;
    public usuarioController( )
    {
        service = new UsuarioService();

    }

    [HttpPost("adicionar-usuario")]
    public void adicionaraluno(usuario u)
    {
        service.Adicionar(u);
    }
}
