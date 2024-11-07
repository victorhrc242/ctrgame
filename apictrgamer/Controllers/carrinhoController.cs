using AutoMapper;
using ctrgamer._01_service;
using ctrgamer._01_service.Interfaces;
using ctrgamer._03_entidades;
using ctrgamer._03_entidades.DTO.carrinho;
using Microsoft.AspNetCore.Mvc;

namespace apictrgamer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarrinhoController : ControllerBase
    {
        private readonly ICarrinhoservice service; 
        private readonly IMapper mapper;  

     
        public CarrinhoController(IMapper _mapper, IConfiguration configuration, ICarrinhoservice carrinhoservice)
        {
            string connectionString = configuration.GetConnectionString("DefaultConnection");  
            service = carrinhoservice;  
            mapper = _mapper; 
        }

        /// <summary>
        /// Adiciona um novo item ao carrinho de compras.
        /// </summary>
        /// <param name="carrinhoDTO">Objeto do tipo Carrinho contendo os dados do novo item a ser adicionado.</param>
        [HttpPost("adicionar-carrinho")]
        public void AdicionarAluno(Carrinho carrinhoDTO)
        {
            Carrinho carrinho = mapper.Map<Carrinho>(carrinhoDTO);  // Mapeia o DTO para a entidade Carrinho
            service.Adicionar(carrinho);  // Chama o serviço para adicionar o item ao carrinho
        }

        /// <summary>
        /// Lista todos os itens no carrinho de compras.
        /// </summary>
        /// <returns>Lista de objetos do tipo Carrinho contendo todos os itens no carrinho.</returns>
        [HttpGet("Listar-compras")]
        public List<Carrinho> listar()
        {
            return service.Listar();  // Chama o serviço para listar todos os itens do carrinho
        }

        /// <summary>
        /// Lista os itens do carrinho de um usuário específico.
        /// </summary>
        /// <param name="usuarioid">ID do usuário para obter o carrinho específico.</param>
        /// <returns>Lista de objetos do tipo Reeadcarrinho, representando os itens no carrinho do usuário.</returns>
        [HttpGet("Listar-carrino")]
        public List<Reeadcarrinho> listarcarrinhodousuario(int usuarioid)
        {
            return service.listarcarrinhodousuario(usuarioid);  // Chama o serviço para listar os itens do carrinho do usuário com o ID fornecido
        }

        /// <summary>
        /// Remove um item do carrinho de compras.
        /// </summary>
        /// <param name="id">ID do item a ser removido do carrinho.</param>
        [HttpDelete("Remover-compras")]
        public void Removeracompra(int id)
        {
            service.Remover(id);  // Chama o serviço para remover o item do carrinho com o ID especificado
        }

        /// <summary>
        /// Edita um item no carrinho de compras.
        /// </summary>
        /// <param name="c">Objeto do tipo Carrinho contendo os dados atualizados do item.</param>
        [HttpPut("editar-compra")]
        public void editarcompra(Carrinho c)
        {
            service.editar(c);  // Chama o serviço para editar o item no carrinho com os dados fornecidos
        }
    }
}
