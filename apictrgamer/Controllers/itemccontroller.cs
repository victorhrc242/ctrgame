using AutoMapper;
using ctrgamer._01_service;
using ctrgamer._03_entidades.DTO.usuario;
using ctrgamer._03_entidades;
using Microsoft.AspNetCore.Mvc;

namespace apictrgamer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class itemccontroller:ControllerBase
    {
        private readonly itemcompraservice service;
        private readonly IMapper mapper;
        public itemccontroller(IMapper _mapper, IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("DefaultConnection");
            service = new itemcompraservice(connectionString);
            _mapper = mapper;

        }

        [HttpPost("adicionar-usuario")]
        public void adicionaraluno(ItemCompra u)
        {
            ItemCompra usuario = mapper.Map<ItemCompra>(u);
            service.Adicionar(usuario);
        }

        [HttpGet("Listar-aluno")]
        public List<ItemCompra> Listaraluno()
        {
            return service.Listar();
        }
        [HttpDelete("Remover-aluno")]
        public void Removeralunoaluno(int id)
        {
            service.Remover(id);
        }
        [HttpPut("editar-aluno")]
        public void editaraluno(ItemCompra usuario)
        {
            service.editar(usuario);
        }
    }
}
