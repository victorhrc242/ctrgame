using AutoMapper;
using ctrgamer._01_service;
using ctrgamer._03_entidades;
using ctrgamer._03_entidades.DTO.usuario;
using Microsoft.AspNetCore.Mvc;

namespace apictrgamer.Controllers;
[ApiController]
[Route("[controller]")]
public class usuarioController :ControllerBase
{

    private readonly  UsuarioService service;
    private readonly IMapper mapper;
    public usuarioController(IMapper _mapper, IConfiguration configuration)
    {
        string connectionString = configuration.GetConnectionString("DefaultConnection");
        service = new UsuarioService(connectionString);
        mapper = _mapper;

    }

    [HttpPost("adicionar-usuario")]
    public void adicionaraluno(createusuario u)
    {
        usuario usuario=mapper.Map<usuario>(u);
        service.Adicionar(usuario);
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
