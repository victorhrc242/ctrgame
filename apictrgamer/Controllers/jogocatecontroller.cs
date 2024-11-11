using AutoMapper;  // Importa o AutoMapper, usado para mapear objetos entre DTOs e entidades
using ctrgamer._01_service;  // Namespace do serviço que contém a lógica de negócio para categorias de jogos
using ctrgamer._01_service.Interfaces;  // Interfaces do serviço de categorias de jogos
using ctrgamer._03_entidades;  // Contém as entidades de domínio, como JogoCategoria
using ctrgamer._03_entidades.DTO.Categorias;  // Contém os DTOs relacionados às categorias de jogos
using Microsoft.AspNetCore.Mvc;  // Usado para criar controladores em ASP.NET Core

namespace apictrgamer.Controllers
{
    // Define a classe do controlador para a API de categorias de jogos
    [ApiController]  // Define que esta classe é um controlador da API
    [Route("[controller]")]  // Define a rota base para o controlador (nome do controlador será usado na rota)
    public class jogocatecontroller : ControllerBase
    {
        // Declaração das dependências necessárias
        private readonly IJogocategoriaservice service;  // Interface do serviço de categorias de jogos, responsável pela lógica de manipulação de dados
        private readonly IMapper mapper;  // AutoMapper, utilizado para mapear entre objetos DTO e entidades

        // Construtor da classe, responsável pela injeção de dependências
        public jogocatecontroller(IMapper _mapper, IConfiguration configuration, IJogocategoriaservice jogocategoriaservice)
        {
            // Obtém a string de conexão a partir do arquivo de configuração (não é utilizado diretamente aqui)
            string connectionString = configuration.GetConnectionString("DefaultConnection");

            // Atribui as dependências passadas para as variáveis de instância
            service = jogocategoriaservice;
            mapper = _mapper;  // Atribui o AutoMapper à variável de instância
        }

        /// <summary>
        /// Endpoint para adicionar uma categoria de jogo
        /// </summary>
        /// <param name="u">Objeto DTO contendo as informações da categoria de jogo a ser adicionada</param>
        [HttpPost("adicionar-usuario")]  // Define a rota para adicionar uma categoria de jogo
        public IActionResult adicionarCategoria(JogoCategoria u)
        {
            try
            {
                // Mapeia o objeto DTO JogoCategoria para a entidade JogoCategoria
                JogoCategoria categoria = mapper.Map<JogoCategoria>(u);

                // Chama o serviço para adicionar a categoria à base de dados
                service.Adicionar(categoria);

                // Retorna status 200 OK indicando que a categoria foi adicionada com sucesso
                return Ok("Categoria de jogo adicionada com sucesso.");
            }
            catch (Exception erro)
            {
                // Retorna um erro 400 BadRequest caso ocorra algum erro no processo
                return BadRequest($"Erro ao adicionar a categoria de jogo: {erro.Message}");
            }
        }

        /// <summary>
        /// Endpoint para listar todas as categorias de jogos
        /// </summary>
        [HttpGet("Listar-aluno")]  // Define a rota para listar todas as categorias de jogos
        public List<JogoCategoria> ListarCategorias()
        {
            // Chama o serviço para listar todas as categorias de jogos
            return service.Listar();
        }

        /// <summary>
        /// Endpoint para listar jogos por categoria
        /// </summary>
        /// <param name="Jogocategoria">ID da categoria de jogos a ser listada</param>
        [HttpGet("Listar-categoria")]  // Define a rota para listar jogos por categoria
        public List<ReadCategoria> ListarJogosPorCategoria(int Jogocategoria)
        {
            // Chama o serviço para listar os jogos de uma determinada categoria
            return service.ListarJogoPorCategoria(Jogocategoria);
        }

        /// <summary>
        /// Endpoint para remover uma categoria de jogo
        /// </summary>
        /// <param name="id">ID da categoria de jogo a ser removida</param>
        [HttpDelete("Remover-aluno")]  // Define a rota para remover uma categoria de jogo
        public IActionResult RemoverCategoria(int id)
        {
            try
            {
                // Chama o serviço para remover a categoria pela ID
                service.Remover(id);

                // Retorna status 200 OK indicando que a categoria foi removida com sucesso
                return Ok("Categoria de jogo removida com sucesso.");
            }
            catch (Exception erro)
            {
                // Se ocorrer erro, retorna uma resposta com código 400 e a mensagem do erro
                return BadRequest($"Erro ao remover a categoria de jogo: {erro.Message}");
            }
        }

        /// <summary>
        /// Endpoint para editar as informações de uma categoria de jogo
        /// </summary>
        /// <param name="usuario">Objeto contendo as novas informações da categoria de jogo</param>
        [HttpPut("editar-aluno")]  // Define a rota para editar uma categoria de jogo
        public IActionResult EditarCategoria(JogoCategoria usuario)
        {
            try
            {
                // Chama o serviço para editar as informações da categoria de jogo
                service.editar(usuario);

                // Retorna status 200 OK indicando que a categoria foi editada com sucesso
                return Ok("Categoria de jogo editada com sucesso.");
            }
            catch (Exception erro)
            {
                // Se ocorrer erro, retorna uma resposta com código 400 e a mensagem do erro
                return BadRequest($"Erro ao editar a categoria de jogo: {erro.Message}");
            }
        }
    }
}
