using AutoMapper;
using ctrgamer._01_service;
using ctrgamer._01_service.Interfaces;
using ctrgamer._03_entidades;
using Microsoft.AspNetCore.Mvc;

namespace apictrgamer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoriaController : ControllerBase
    {
        private readonly Icategoriasservice service;
        private readonly IMapper mapper;  

       
        public CategoriaController(IMapper _mapper, IConfiguration configuration, Icategoriasservice icategoriasservice)
        {
            string connectionString = configuration.GetConnectionString("DefaultConnection");  
            service = icategoriasservice;  
            mapper = _mapper;  
        }

        /// <summary>
        /// Adiciona uma nova categoria ao sistema.
        /// </summary>
        /// <param name="u">Objeto do tipo Categoria contendo os dados da nova categoria a ser adicionada.</param>
        [HttpPost("adicionar-usuario")]
        public void adicionaraluno(Categoria u)
        {
            Categoria categoria = mapper.Map<Categoria>(u);  // Mapeia o DTO para a entidade Categoria
            service.Adicionar(categoria);  // Chama o serviço para adicionar a categoria
        }

        /// <summary>
        /// Lista todas as categorias cadastradas no sistema.
        /// </summary>
        /// <returns>Lista de objetos do tipo Categoria contendo todas as categorias cadastradas.</returns>
        [HttpGet("Listar-aluno")]
        public List<Categoria> Listaraluno()
        {
            return service.Listar();  // Chama o serviço para listar todas as categorias
        }

        /// <summary>
        /// Remove uma categoria do sistema com base no ID fornecido.
        /// </summary>
        /// <param name="id">ID da categoria a ser removida.</param>
        [HttpDelete("Remover-aluno")]
        public void Removeralunoaluno(int id)
        {
            service.Remover(id);  // Chama o serviço para remover a categoria com o ID especificado
        }

        /// <summary>
        /// Edita os dados de uma categoria existente no sistema.
        /// </summary>
        /// <param name="usuario">Objeto do tipo Categoria contendo os dados atualizados da categoria.</param>
        [HttpPut("editar-aluno")]
        public void editaraluno(Categoria usuario)
        {
            service.editar(usuario);  // Chama o serviço para editar a categoria com os dados fornecidos
        }
    }
}
