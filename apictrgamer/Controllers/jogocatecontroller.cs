using AutoMapper;
using ctrgamer._01_service;
using ctrgamer._01_service.Interfaces;
using ctrgamer._03_entidades;
using ctrgamer._03_entidades.DTO.Categorias;
using Microsoft.AspNetCore.Mvc;

namespace apictrgamer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class JogoCateController : ControllerBase
    {
        private readonly IJogocategoriaservice service;  // Serviço responsável pelas operações de categorias de jogos
        private readonly IMapper mapper;  // Mapeador para conversão de DTOs

        // Construtor que injeta as dependências necessárias: o serviço de categorias e o mapeador
        public JogoCateController(IMapper _mapper, IConfiguration configuration, IJogocategoriaservice jogocategoriaservice)
        {
            string connectionString = configuration.GetConnectionString("DefaultConnection");  // Obtém a string de conexão com o banco de dados
            service = jogocategoriaservice;  // Inicializa o serviço de categorias de jogos
            mapper = _mapper;  // Inicializa o mapeador para conversão entre DTOs e entidades
        }

        /// <summary>
        /// Adiciona uma nova categoria de jogo ao sistema.
        /// </summary>
        /// <param name="u">Objeto do tipo JogoCategoria contendo os dados da nova categoria a ser adicionada.</param>
        [HttpPost("adicionar-usuario")]
        public void adicionaraluno(JogoCategoria u)
        {
            JogoCategoria categoria = mapper.Map<JogoCategoria>(u);  // Mapeia o DTO para a entidade JogoCategoria
            service.Adicionar(categoria);  // Chama o serviço para adicionar a categoria de jogo
        }

        /// <summary>
        /// Lista todas as categorias de jogos cadastradas no sistema.
        /// </summary>
        /// <returns>Lista de objetos do tipo JogoCategoria contendo todas as categorias de jogos cadastradas.</returns>
        [HttpGet("Listar-aluno")]
        public List<JogoCategoria> Listaraluno()
        {
            return service.Listar();  // Chama o serviço para listar todas as categorias de jogos
        }

        /// <summary>
        /// Lista os jogos filtrados por categoria.
        /// </summary>
        /// <param name="Jogocategoria">ID da categoria de jogos que será usada como filtro.</param>
        /// <returns>Lista de objetos ReadCategoria contendo os jogos pertencentes à categoria especificada.</returns>
        [HttpGet("Listar-categoria")]
        public List<ReadCategoria> listarjogoporcategoria(int Jogocategoria)
        {
            return service.ListarJogoPorCategoria(Jogocategoria);  // Chama o serviço para listar jogos de uma categoria específica
        }

        /// <summary>
        /// Remove uma categoria de jogo do sistema com base no ID fornecido.
        /// </summary>
        /// <param name="id">ID da categoria de jogo a ser removida.</param>
        [HttpDelete("Remover-aluno")]
        public void Removeralunoaluno(int id)
        {
            service.Remover(id);  // Chama o serviço para remover a categoria de jogo com o ID especificado
        }

        /// <summary>
        /// Edita os dados de uma categoria de jogo existente no sistema.
        /// </summary>
        /// <param name="usuario">Objeto do tipo JogoCategoria contendo os dados atualizados da categoria.</param>
        [HttpPut("editar-aluno")]
        public void editaraluno(JogoCategoria usuario)
        {
            service.editar(usuario);  // Chama o serviço para editar a categoria de jogo com os dados fornecidos
        }
    }
}
