using ctrgamer._01_service;
using ctrgamer._03_entidades;
using Microsoft.AspNetCore.Mvc;

namespace apictrgamer.Controllers;
[ApiController]
[Route("[controller]")]
public class usuarioController :ControllerBase
{

    private readonly  UsuarioService service;
    public usuarioController(IConfiguration configuration)
    {
        string connectionString = configuration.GetConnectionString("DefaultConnection");
        service = new UsuarioService(connectionString);

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
    public void editaraluno( usuario usuario)
    {
        service.editar(usuario);
    }
}
