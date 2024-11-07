using AutoMapper;
using ctrgamer._01_service;
using ctrgamer._01_service.Interfaces;
using ctrgamer._03_entidades;
using Microsoft.AspNetCore.Mvc;

namespace apictrgamer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RevendedorController : ControllerBase
    {
        private readonly IReevendedoservice service;  
        private readonly IMapper mapper; 

 
        public RevendedorController(IMapper _mapper, IConfiguration configuration, reevedendorservice_ reevedendorservice)
        {
            string connectionString = configuration.GetConnectionString("DefaultConnection"); 
            service = reevedendorservice;  
            mapper = _mapper;  
        }

        /// <summary>
        /// Adiciona um novo revendedor ao sistema.
        /// </summary>
        /// <param name="u">Objeto do tipo Reevendedor contendo os dados do novo revendedor.</param>
        [HttpPost("adicionar-Revenddedor")]
        public void adicionaraluno(Reevendedor u)
        {
            Reevendedor revendedor = mapper.Map<Reevendedor>(u);  // Mapeia o DTO para a entidade Reevendedor
            service.Adicionar(revendedor);  // Chama o serviço para adicionar o revendedor
        }

        /// <summary>
        /// Lista todos os revendedores registrados no sistema.
        /// </summary>
        /// <returns>Lista de objetos do tipo Reevendedor contendo todos os revendedores registrados.</returns>
        [HttpGet("Listar-Revendedores")]
        public List<Reevendedor> Listaraluno()
        {
            return service.Listar();  // Chama o serviço para listar todos os revendedores
        }

        /// <summary>
        /// Remove um revendedor do sistema com base no ID fornecido.
        /// </summary>
        /// <param name="id">ID do revendedor a ser removido.</param>
        [HttpDelete("Remover-Revendedor")]
        public void Removeralunoaluno(int id)
        {
            service.Remover(id);  // Chama o serviço para remover o revendedor com o ID especificado
        }

        /// <summary>
        /// Edita os dados de um revendedor existente no sistema.
        /// </summary>
        /// <param name="usuario">Objeto do tipo Reevendedor contendo os dados atualizados do revendedor.</param>
        [HttpPut("editar-Revendedor")]
        public void editaraluno(Reevendedor usuario)
        {
            service.editar(usuario);  // Chama o serviço para editar o revendedor com os dados fornecidos
        }
    }
}
