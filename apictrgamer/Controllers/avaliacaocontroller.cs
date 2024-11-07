using AutoMapper;
using ctrgamer._01_service;
using ctrgamer._01_service.Interfaces;
using ctrgamer._03_entidades;
using Microsoft.AspNetCore.Mvc;

namespace apictrgamer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class avaliacaocontroller : ControllerBase
    {
        private readonly IAvaliacaoservice service;
        private readonly IMapper mapper;

      
        public avaliacaocontroller(IMapper _mapper, IConfiguration configuration, IAvaliacaoservice avaliacaoservice)
        {
            string connectionString = configuration.GetConnectionString("DefaultConnection"); 
            service = avaliacaoservice;  
            mapper = _mapper; 
        }

        /// <summary>
        /// Adiciona uma nova avaliação no sistema.
        /// </summary>
        /// <param name="u">Objeto Avaliacao contendo os dados da nova avaliação.</param>
        [HttpPost("adicionar-Avaliação")]
        public void adicionaraluno(Avaliacao u)
        {
            Avaliacao usuario = mapper.Map<Avaliacao>(u);  // Mapeia o objeto de entrada para o tipo Avaliacao
            service.Adicionar(usuario);  // Chama o serviço para adicionar a avaliação
        }

        /// <summary>
        /// Lista todas as avaliações cadastradas no sistema.
        /// </summary>
        /// <returns>Lista de avaliações.</returns>
        [HttpGet("Listar-Avaliações")]
        public List<Avaliacao> Listaraluno()
        {
            return service.Listar();  // Chama o serviço para listar todas as avaliações
        }

        /// <summary>
        /// Remove uma avaliação do sistema com base no ID fornecido.
        /// </summary>
        /// <param name="id">ID da avaliação a ser removida.</param>
        [HttpDelete("Remover-Avaliação")]
        public void Removeralunoaluno(int id)
        {
            service.Remover(id);  // Chama o serviço para remover a avaliação com o ID fornecido
        }

        /// <summary>
        /// Edita uma avaliação existente no sistema.
        /// </summary>
        /// <param name="usuario">Objeto Avaliacao contendo os dados atualizados.</param>
        [HttpPut("editar-Avaliação")]
        public void editaraluno(Avaliacao usuario)
        {
            service.editar(usuario);  // Chama o serviço para editar a avaliação
        }
    }
}
