using AutoMapper;  // Importa o AutoMapper, usado para mapear objetos entre DTOs e entidades
using ctrgamer._01_service;  // Namespace do serviço que contém a lógica de negócio para jogos
using ctrgamer._01_service.Interfaces;  // Interfaces do serviço de jogos
using ctrgamer._03_entidades;  // Contém as entidades de domínio (como Jogo, etc.)
using Microsoft.AspNetCore.Mvc;  // Usado para criar controladores em ASP.NET Core

namespace apictrgamer.Controllers
{
    // Define a classe do controlador para a API de jogos
    [ApiController]  // Define que esta classe é um controlador da API
    [Route("[controller]")]  // Define a rota base para o controlador (nome do controlador será usado na rota)
    public class jogoscontroller : ControllerBase
    {
        // Declaração das dependências necessárias
        private readonly IJogoservice service;  // Interface do serviço de jogos, responsável pela lógica de manipulação de dados
        private readonly IMapper mapper;  // AutoMapper, utilizado para mapear entre objetos DTO e entidades

        // Construtor da classe, responsável pela injeção de dependências
        public jogoscontroller(IMapper _mapper, IConfiguration configuration, IJogoservice jogoservice)
        {
            // Obtém a string de conexão a partir do arquivo de configuração (não é utilizado diretamente aqui)
            string connectionString = configuration.GetConnectionString("DefaultConnection");

            // Atribui as dependências passadas para as variáveis de instância
            service = jogoservice;
            mapper = _mapper;  // Atribui o AutoMapper à variável de instância
        }

        /// <summary>
        /// Endpoint para adicionar um jogo
        /// </summary>
        /// <param name="j">Objeto DTO contendo as informações do jogo a ser adicionado</param>
        [HttpPost("adicionar-jogo")]  // Define a rota para adicionar um jogo
        public IActionResult adicionarJogo(Jogo j)
        {
            try
            {
                // Mapeia o objeto DTO Jogo para a entidade Jogo
                Jogo jogo = mapper.Map<Jogo>(j);

                // Chama o serviço para adicionar o jogo à base de dados
                service.Adicionar(jogo);

                // Retorna status 200 OK indicando que o jogo foi adicionado com sucesso
                return Ok("Jogo adicionado com sucesso.");
            }
            catch (Exception erro)
            {
                // Retorna um erro 400 BadRequest caso ocorra algum erro no processo
                return BadRequest($"Erro ao adicionar o jogo: {erro.Message}");
            }
        }

        /// <summary>
        /// Endpoint para listar todos os jogos
        /// </summary>
        [HttpGet("Listar-jogos")]  // Define a rota para listar todos os jogos
        public List<Jogo> ListarJogos()
        {
            // Chama o serviço para listar todos os jogos
            return service.Listar();
        }

        /// <summary>
        /// Endpoint para remover um jogo
        /// </summary>
        /// <param name="id">ID do jogo a ser removido</param>
        [HttpDelete("Remover-jogos")]  // Define a rota para remover um jogo
        public IActionResult RemoverJogo(int id)
        {
            try
            {
                // Chama o serviço para remover o jogo pela ID
                service.Remover(id);

                // Retorna status 200 OK indicando que o jogo foi removido com sucesso
                return Ok("Jogo removido com sucesso.");
            }
            catch (Exception erro)
            {
                // Se ocorrer erro, retorna uma resposta com código 400 e a mensagem do erro
                return BadRequest($"Erro ao remover o jogo: {erro.Message}");
            }
        }

        /// <summary>
        /// Endpoint para editar as informações de um jogo
        /// </summary>
        /// <param name="J">Objeto contendo as novas informações do jogo</param>
        [HttpPut("editar-jogo")]  // Define a rota para editar um jogo
        public IActionResult EditarJogo(Jogo j)
        {
            try
            {
                // Chama o serviço para editar as informações do jogo
                service.editar(j);

                // Retorna status 200 OK indicando que o jogo foi editado com sucesso
                return Ok("Jogo editado com sucesso.");
            }
            catch (Exception erro)
            {
                // Se ocorrer erro, retorna uma resposta com código 400 e a mensagem do erro
                return BadRequest($"Erro ao editar o jogo: {erro.Message}");
            }
        }
    }
}
