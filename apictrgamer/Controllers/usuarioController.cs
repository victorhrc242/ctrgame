using AutoMapper;
using ctrgamer._01_service;
using ctrgamer._01_service.Interfaces;
using ctrgamer._03_entidades;
using ctrgamer._03_entidades.DTO;
using ctrgamer._03_entidades.DTO;
using FrontEnd.DTOS;
using Microsoft.AspNetCore.Mvc;

namespace apictrgamer.Controllers;
[ApiController]
[Route("[controller]")]
public class usuarioController :ControllerBase
{

    private readonly  IUsuarioservice _service;
    private readonly IMapper mapper;
    public usuarioController(IMapper _mapper, IConfiguration configuration)
    {
        string connectionString = configuration.GetConnectionString("DefaultConnection");
        _service = new UsuarioService(connectionString);
        mapper = _mapper;

    }

    [HttpPost("adicionar-usuario")]
    public void adicionaraluno(usuarioS u)
    {
        usuarioS usuario=mapper.Map<usuarioS>(u);
        _service.Adicionar(usuario);
    }
    [HttpPost("fazer-login")]
    public usuarioS FazerLogin(Usuariologindto usuarioLogin)
    {
        usuarioS usuario =  _service.FazerLogin(usuarioLogin);
        return usuario;
    }
    [HttpGet("Listar-usuarios")]
    public List<usuarioS> Listaraluno()
    {
        return _service.Listar();
    }
    [HttpDelete("Remover-usuario")]
    public void Removeralunoaluno(int id)
    {
        _service.Remover(id);
    }
    [HttpPut("editar-usuario")]
    public void editaraluno( usuarioS usuario)
    {
        _service.editar(usuario);
    }
}
