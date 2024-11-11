using AutoMapper;  // Importa o AutoMapper, utilizado para mapear objetos entre DTOs e entidades
using ctrgamer._01_service;  // Namespace do serviço que contém a lógica de negócio para categorias
using ctrgamer._01_service.Interfaces;  // Interfaces do serviço de categorias
using ctrgamer._03_entidades;  // Contém as entidades de domínio, como Categoria
using Microsoft.AspNetCore.Mvc;  // Usado para criar controladores em ASP.NET Core

namespace apictrgamer.Controllers
{
    // Define a classe do controlador para a API de categorias
    [ApiController]  // Define que esta classe é um controlador da API
    [Route("[controller]")]  // Define a rota base para o controlador (nome do controlador será usado na rota)
    public class categoriacontroller : ControllerBase
    {
        // Declaração das dependências necessárias
        private readonly Icategoriasservice service;  // Interface do serviço de categorias, responsável pela lógica de manipulação de dados
        private readonly IMapper mapper;  // AutoMapper, utilizado para mapear entre objetos DTO e entidades

        // Construtor da classe, responsável pela injeção de dependências
        public categoriacontroller(IMapper _mapper, IConfiguration configuration, Icategoriasservice icategoriasservice)
        {
            // Obtém a string de conexão a partir do arquivo de configuração (não é utilizado diretamente aqui)
            string connectionString = configuration.GetConnectionString("DefaultConnection");

            // Atribui as dependências passadas para as variáveis de instância
            service = icategoriasservice;
            mapper = _mapper;  // Atribui o AutoMapper à variável de instância
        }

        /// <summary>
        /// Endpoint para adicionar uma categoria
        /// </summary>
        /// <param name="u">Objeto DTO contendo as informações da categoria a ser adicionada</param>
        [HttpPost("adicionar-usuario")]  // Define a rota para adicionar uma categoria
        public IActionResult adicionarCategoria(Categoria u)
        {
            try
            {
                // Mapeia o objeto DTO Categoria para a entidade Categoria
                Categoria categoria = mapper.Map<Categoria>(u);

                // Chama o serviço para adicionar a categoria à base de dados
                service.Adicionar(categoria);

                // Retorna status 200 OK indicando que a categoria foi adicionada com sucesso
                return Ok("Categoria adicionada com sucesso.");
            }
            catch (Exception erro)
            {
                // Se ocorrer erro, retorna uma resposta com código 400 e a mensagem do erro
                return BadRequest($"Erro ao adicionar a categoria: {erro.Message}");
            }
        }

        /// <summary>
        /// Endpoint para listar todas as categorias
        /// </summary>
        [HttpGet("Listar-aluno")]  // Define a rota para listar todas as categorias
        public List<Categoria> ListarCategorias()
        {
            // Chama o serviço para listar todas as categorias
            return service.Listar();
        }

        /// <summary>
        /// Endpoint para remover uma categoria
        /// </summary>
        /// <param name="id">ID da categoria a ser removida</param>
        [HttpDelete("Remover-aluno")]  // Define a rota para remover uma categoria
        public IActionResult RemoverCategoria(int id)
        {
            try
            {
                // Chama o serviço para remover a categoria pela ID
                service.Remover(id);

                // Retorna status 200 OK indicando que a categoria foi removida com sucesso
                return Ok("Categoria removida com sucesso.");
            }
            catch (Exception erro)
            {
                // Se ocorrer erro, retorna uma resposta com código 400 e a mensagem do erro
                return BadRequest($"Erro ao remover a categoria: {erro.Message}");
            }
        }

        /// <summary>
        /// Endpoint para editar as informações de uma categoria
        /// </summary>
        /// <param name="usuario">Objeto contendo as novas informações da categoria</param>
        [HttpPut("editar-aluno")]  // Define a rota para editar uma categoria
        public IActionResult EditarCategoria(Categoria usuario)
        {
            try
            {
                // Chama o serviço para editar as informações da categoria
                service.editar(usuario);

                // Retorna status 200 OK indicando que a categoria foi editada com sucesso
                return Ok("Categoria editada com sucesso.");
            }
            catch (Exception erro)
            {
                // Se ocorrer erro, retorna uma resposta com código 400 e a mensagem do erro
                return BadRequest($"Erro ao editar a categoria: {erro.Message}");
            }
        }
    }
}
