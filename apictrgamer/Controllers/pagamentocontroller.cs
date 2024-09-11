using AutoMapper;
using ctrgamer._01_service;
using ctrgamer._03_entidades.DTO.usuario;
using ctrgamer._03_entidades;
using Microsoft.AspNetCore.Mvc;

namespace apictrgamer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class pagamentocontroller:ControllerBase
    {
        private readonly pagamentoservice service;
        private readonly IMapper mapper;
        public pagamentocontroller(IMapper _mapper, IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("DefaultConnection");
            service = new pagamentoservice(connectionString);
            _mapper = mapper;

        }

        [HttpPost("adicionar-usuario")]
        public void adicionaraluno(Pagamento u)
        {
            Pagamento usuario = mapper.Map<Pagamento>(u);
            service.Adicionar(usuario);
        }

        [HttpGet("Listar-aluno")]
        public List<Pagamento> Listaraluno()
        {
            return service.Listar();
        }
        [HttpDelete("Remover-aluno")]
        public void Removeralunoaluno(int id)
        {
            service.Remover(id);
        }
        [HttpPut("editar-aluno")]
        public void editaraluno(Pagamento usuario)
        {
            service.editar(usuario);
        }
    }
}
