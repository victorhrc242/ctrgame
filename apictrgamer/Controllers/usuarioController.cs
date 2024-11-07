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
    public usuarioController(IMapper _mapper, IConfiguration configuration,IUsuarioservice usuarioservice)
    {
        string connectionString = configuration.GetConnectionString("DefaultConnection");
        _service = usuarioservice;
        mapper = _mapper;

    }


    /// <summary>
    /// Adiciona um novo usuário no sistema.
    /// </summary>
    /// <param name="u">Objeto do tipo usuarioS contendo os dados do novo usuário.</param>
    [HttpPost("adicionar-usuario")]
    public void adicionaraluno(usuarioS u)
    {
        usuarioS usuario = mapper.Map<usuarioS>(u);  // Mapeia o objeto de entrada para a entidade usuarioS
        _service.Adicionar(usuario);  // Chama o serviço para adicionar o usuário
    }

    /// <summary>
    /// Realiza o login de um usuário no sistema.
    /// </summary>
    /// <param name="usuarioLogin">Objeto do tipo Usuariologindto contendo as credenciais do usuário.</param>
    /// <returns>Retorna o usuário autenticado, se as credenciais forem válidas.</returns>
    [HttpPost("fazer-login")]
    public usuarioS FazerLogin(Usuariologindto usuarioLogin)
    {
        usuarioS usuario = _service.FazerLogin(usuarioLogin);  // Chama o serviço para realizar o login
        return usuario;  // Retorna o usuário autenticado ou null se não for válido
    }

    /// <summary>
    /// Lista todos os usuários cadastrados no sistema.
    /// </summary>
    /// <returns>Lista de objetos do tipo usuarioS contendo os dados de todos os usuários.</returns>
    [HttpGet("Listar-usuarios")]
    public List<usuarioS> Listaraluno()
    {
        return _service.Listar();  // Chama o serviço para listar todos os usuários
    }

    /// <summary>
    /// Remove um usuário do sistema baseado no ID fornecido.
    /// </summary>
    /// <param name="id">ID do usuário a ser removido.</param>
    [HttpDelete("Remover-usuario")]
    public void Removeralunoaluno(int id)
    {
        _service.Remover(id);  // Chama o serviço para remover o usuário com o ID especificado
    }

    /// <summary>
    /// Edita os dados de um usuário existente no sistema.
    /// </summary>
    /// <param name="usuario">Objeto do tipo usuarioS contendo os dados atualizados do usuário.</param>
    [HttpPut("editar-usuario")]
    public void editaraluno(usuarioS usuario)
    {
        _service.editar(usuario);  // Chama o serviço para editar o usuário
    }
}
