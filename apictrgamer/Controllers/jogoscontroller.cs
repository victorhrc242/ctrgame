using AutoMapper;
using ctrgamer._01_service;
using ctrgamer._01_service.Interfaces;
using ctrgamer._03_entidades;
using Microsoft.AspNetCore.Mvc;

namespace apictrgamer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class JogosController : ControllerBase
    {
        private readonly IJogoservice service;  
        private readonly IMapper mapper;  
        public JogosController(IMapper _mapper, IConfiguration configuration, IJogoservice jogoservice)
        {
            string connectionString = configuration.GetConnectionString("DefaultConnection"); 
            service = jogoservice; 
            mapper = _mapper; 
        }

        /// <summary>
        /// Adiciona um novo jogo ao sistema.
        /// </summary>
        /// <param name="j">Objeto do tipo Jogo contendo os dados do novo jogo.</param>
        [HttpPost("adicionar-jogo")]
        public void adicionaraluno(Jogo j)
        {
            Jogo jogo = mapper.Map<Jogo>(j);  // Mapeia o objeto de entrada para a entidade Jogo
            service.Adicionar(jogo);  // Chama o serviço para adicionar o novo jogo
        }

        /// <summary>
        /// Lista todos os jogos cadastrados no sistema.
        /// </summary>
        /// <returns>Lista de objetos do tipo Jogo contendo todos os jogos cadastrados.</returns>
        [HttpGet("Listar-jogos")]
        public List<Jogo> Listaraluno()
        {
            return service.Listar();  // Chama o serviço para listar todos os jogos
        }

        /// <summary>
        /// Remove um jogo do sistema com base no ID fornecido.
        /// </summary>
        /// <param name="id">ID do jogo a ser removido.</param>
        [HttpDelete("Remover-jogos")]
        public void Removeralunoaluno(int id)
        {
            service.Remover(id);  // Chama o serviço para remover o jogo com o ID especificado
        }

        /// <summary>
        /// Edita os dados de um jogo existente no sistema.
        /// </summary>
        /// <param name="J">Objeto do tipo Jogo contendo os dados atualizados do jogo.</param>
        [HttpPut("editar-jogo")]
        public void editaraluno(Jogo J)
        {
            service.editar(J);  // Chama o serviço para editar o jogo com os dados fornecidos
        }
    }
}
