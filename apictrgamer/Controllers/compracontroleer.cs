using AutoMapper;
using ctrgamer._01_service;
using ctrgamer._03_entidades;
using Microsoft.AspNetCore.Mvc;

namespace apictrgamer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class compracontroleer:ControllerBase
    {
        private readonly compraservice service;
        private readonly IMapper mapper;
        public compracontroleer(IMapper _mapper, IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("DefaultConnection");
            service = new compraservice(connectionString);
            mapper = _mapper;

        }

        [HttpPost("adicionar-usuario")]
        public void adicionaraluno(Compra c)
        {
            Compra usuario = mapper.Map<Compra>(c);
            service.Adicionar(usuario);
        }

        [HttpGet("Listar-aluno")]
        public List<Compra> Listaraluno()
        {
            return service.Listar();
        }
        [HttpDelete("Remover-aluno")]
        public void Removeralunoaluno(int id)
        {
            service.Remover(id);
        }
        [HttpPut("editar-aluno")]
        public void editaraluno(Compra usuario)
        {
            service.editar(usuario);
        }
    }
}
