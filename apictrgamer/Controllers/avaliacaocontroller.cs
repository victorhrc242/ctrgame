using AutoMapper;  // Importa o AutoMapper, usado para mapear objetos entre DTOs e entidades
using ctrgamer._01_service;  // Namespace do serviço que contém a lógica de negócio para avaliações
using ctrgamer._01_service.Interfaces;  // Interfaces do serviço de avaliações
using ctrgamer._03_entidades;  // Contém as entidades de domínio, como Avaliacao
using Microsoft.AspNetCore.Mvc;  // Usado para criar controladores em ASP.NET Core

namespace apictrgamer.Controllers
{
    // Define a classe do controlador para a API de avaliações
    [ApiController]  // Define que esta classe é um controlador da API
    [Route("[controller]")]  // Define a rota base para o controlador (nome do controlador será usado na rota)
    public class avaliacaocontroller : ControllerBase
    {
        // Declaração das dependências necessárias
        private readonly IAvaliacaoservice service;  // Interface do serviço de avaliações, responsável pela lógica de manipulação de dados
        private readonly IMapper mapper;  // AutoMapper, utilizado para mapear entre objetos DTO e entidades

        // Construtor da classe, responsável pela injeção de dependências
        public avaliacaocontroller(IMapper _mapper, IConfiguration configuration, IAvaliacaoservice avaliacaoservice)
        {
            // Obtém a string de conexão a partir do arquivo de configuração (não é utilizado diretamente aqui)
            string connectionString = configuration.GetConnectionString("DefaultConnection");

            // Atribui as dependências passadas para as variáveis de instância
            service = avaliacaoservice;
            mapper = _mapper;  // Atribui o AutoMapper à variável de instância
        }

        /// <summary>
        /// Endpoint para adicionar uma avaliação
        /// </summary>
        /// <param name="u">Objeto DTO contendo as informações da avaliação a ser adicionada</param>
        [HttpPost("adicionar-Avaliação")]  // Define a rota para adicionar uma avaliação
        public IActionResult adicionarAvaliacao(Avaliacao u)
        {
            try
            {
                // Mapeia o objeto DTO Avaliacao para a entidade Avaliacao
                Avaliacao avaliacao = mapper.Map<Avaliacao>(u);

                // Chama o serviço para adicionar a avaliação à base de dados
                service.Adicionar(avaliacao);

                // Retorna status 200 OK indicando que a avaliação foi adicionada com sucesso
                return Ok("Avaliação adicionada com sucesso.");
            }
            catch (Exception erro)
            {
                // Se ocorrer erro, retorna uma resposta com código 400 e a mensagem do erro
                return BadRequest($"Erro ao adicionar a avaliação: {erro.Message}");
            }
        }

        /// <summary>
        /// Endpoint para listar todas as avaliações
        /// </summary>
        [HttpGet("Listar-Avaliações")]  // Define a rota para listar todas as avaliações
        public List<Avaliacao> ListarAvaliacoes()
        {
            // Chama o serviço para listar todas as avaliações
            return service.Listar();
        }

        /// <summary>
        /// Endpoint para remover uma avaliação
        /// </summary>
        /// <param name="id">ID da avaliação a ser removida</param>
        [HttpDelete("Remover-Avaliação")]  // Define a rota para remover uma avaliação
        public IActionResult RemoverAvaliacao(int id)
        {
            try
            {
                // Chama o serviço para remover a avaliação pela ID
                service.Remover(id);

                // Retorna status 200 OK indicando que a avaliação foi removida com sucesso
                return Ok("Avaliação removida com sucesso.");
            }
            catch (Exception erro)
            {
                // Se ocorrer erro, retorna uma resposta com código 400 e a mensagem do erro
                return BadRequest($"Erro ao remover a avaliação: {erro.Message}");
            }
        }

        /// <summary>
        /// Endpoint para editar as informações de uma avaliação
        /// </summary>
        /// <param name="usuario">Objeto contendo as novas informações da avaliação</param>
        [HttpPut("editar-Avaliação")]  // Define a rota para editar uma avaliação
        public IActionResult EditarAvaliacao(Avaliacao usuario)
        {
            try
            {
                // Chama o serviço para editar as informações da avaliação
                service.editar(usuario);

                // Retorna status 200 OK indicando que a avaliação foi editada com sucesso
                return Ok("Avaliação editada com sucesso.");
            }
            catch (Exception erro)
            {
                // Se ocorrer erro, retorna uma resposta com código 400 e a mensagem do erro
                return BadRequest($"Erro ao editar a avaliação: {erro.Message}");
            }
        }
    }
}
