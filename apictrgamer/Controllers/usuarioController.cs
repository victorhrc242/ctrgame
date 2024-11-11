// Importação das bibliotecas necessárias
using AutoMapper;  // Usado para mapear objetos entre camadas diferentes
using ctrgamer._01_service;  // Namespace que contém o serviço de usuários
using ctrgamer._01_service.Interfaces;  // Interfaces dos serviços
using ctrgamer._03_entidades;  // Contém as entidades, como "usuarioS"
using ctrgamer._03_entidades.DTO;  // Contém as classes DTO (Data Transfer Objects)
using FrontEnd.DTOS;  // Namespace com objetos DTO utilizados no frontend
using Microsoft.AspNetCore.Mvc;  // Usado para criar controladores no ASP.NET Core MVC

// Define a classe como um controlador da API, com os atributos necessários para a exposição de endpoints
namespace apictrgamer.Controllers
{
    [ApiController]  // Indica que esta classe é um controlador da API
    [Route("[controller]")]  // Define a rota base para os endpoints, usando o nome do controlador
    public class usuarioController : ControllerBase
    {
        // Declaração das dependências: um serviço de usuário e o AutoMapper para mapear objetos
        private readonly IUsuarioservice _service;
        private readonly IMapper mapper;

        // Construtor do controlador que recebe as dependências via injeção de dependência
        public usuarioController(IMapper _mapper, IConfiguration configuration, IUsuarioservice usuarioservice)
        {
            // Recupera a string de conexão do arquivo de configuração, não utilizada diretamente aqui
            string connectionString = configuration.GetConnectionString("DefaultConnection");

            // Atribui as dependências às variáveis privadas
            _service = usuarioservice;
            mapper = _mapper;
        }

        /// <summary>
        /// Método para adicionar um usuário (aluno)
        /// </summary>
        /// <param name="u">O objeto de entrada, que representa um novo usuário</param>
        [HttpPost("adicionar-usuario")]  // Define a rota para este endpoint
        public IActionResult adicionaraluno(usuarioS u)
        {
            try
            {
                usuarioS usuario = mapper.Map<usuarioS>(u);
                _service.Adicionar(usuario);
                return Ok();
            }
            catch (Exception erro)
            {

                return BadRequest($"Ocorreu un erro ao adicionar aluno, o erro foi" +
                    $"\n{erro.Message}");
            }
            
        }

        /// <summary>
        /// Método para fazer o login de um usuário
        /// </summary>
        /// <param name="usuarioLogin">DTO com as credenciais para login</param>
        [HttpPost("fazer-login")]  // Define a rota para o login
        public usuarioS FazerLogin(Usuariologindto usuarioLogin)
        {
            // Chama o serviço para realizar o login, passando as credenciais do usuário
            usuarioS usuario = _service.FazerLogin(usuarioLogin);

            // Retorna o usuário encontrado após o login (podendo incluir informações como token, etc.)
            return usuario;
        }

        /// <summary>
        /// Método para listar todos os usuários
        /// </summary>
        [HttpGet("Listar-usuarios")]  // Define a rota para listar os usuários
        public List<usuarioS> Listaraluno()
        {
            // Chama o serviço para listar todos os usuários registrados
            return _service.Listar();
        }

        /// <summary>
        /// Método para remover um usuário pelo seu ID
        /// </summary>
        /// <param name="id">ID do usuário a ser removido</param>
        [HttpDelete("Remover-usuario")]  // Define a rota para deletar o usuário
        public IActionResult Removeralunoaluno(int id)
        {
            try
            {
                _service.Remover(id);
                return Ok();
            }
            catch (Exception erro)
            {

                return BadRequest($"Ocorreu un erro ao adicionar aluno, o erro foi" +
                    $"\n{erro.Message}");
            }
           
        }

        /// <summary>
        /// Método para editar as informações de um usuário
        /// </summary>
        /// <param name="usuario">Objeto contendo as novas informações do usuário</param>
        [HttpPut("editar-usuario")]  // Define a rota para editar um usuário
        public IActionResult editaraluno(usuarioS usuario)
        {
            try
            {
                _service.editar(usuario);
                return Ok();
            }
            catch (Exception erro)
            {

                return BadRequest($"Ocorreu un erro ao adicionar aluno, o erro foi" +
                    $"\n{erro.Message}");
            }

        }
    }
}
