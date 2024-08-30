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

    [HttpGet("Listar-aluno")]
    public List<usuario> Listaraluno()
    {



        return service.Listar();
    }
    [HttpDelete("Remover-aluno")]
    public void Removeralunoaluno(int id)
    {
        service.Remover(id);
    }
    [HttpPut("editar-aluno")]
    public void editaraluno(int id, usuario usuario)
    {
        service.editar(id, usuario);
    }
}
