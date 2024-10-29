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
    public class carrinhoController : ControllerBase
    {
        private readonly ICarrinhoservice service;
        private readonly IMapper mapper;

        public carrinhoController(IMapper _mapper, IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("DefaultConnection");
            service = new carrinhoService(connectionString,mapper);
            mapper = _mapper; // Corrigido para atribuir o parâmetro à variável de instância
        }

        [HttpPost("adicionar-carrinho")]
        public void AdicionarAluno(Carrinho carrinhoDTO)
        {
            Carrinho carrinho = mapper.Map<Carrinho>(carrinhoDTO);
            service.Adicionar(carrinho);
        }

        [HttpGet("Listar-compras")]
        public List<Carrinho> listar()
        {
            return service.Listar();
        }
        [HttpGet("Listar-carrino")]
        public List<Reeadcarrinho> listarcarrinhodousuario(int usuarioid)
        {
            return service.listarcarrinhodousuario(usuarioid);
        }

        [HttpDelete("Remover-compras")]
        public void Removeracompra(int id)
        {
            service.Remover(id);
        }

        [HttpPut("editar-compra")]
        public void editarcompra(Carrinho c)
        {
            service.editar(c);
        }
    }
}
