using AutoMapper;
using ctrgamer._01_service;
using ctrgamer._03_entidades.DTO.usuario;
using ctrgamer._03_entidades;
using Microsoft.AspNetCore.Mvc;

namespace apictrgamer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class jogocatecontroller:ControllerBase
    {
        private readonly jogocategoriaservice service;
        private readonly IMapper mapper;
        public jogocatecontroller(IMapper _mapper, IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("DefaultConnection");
            service = new jogocategoriaservice(connectionString);
            _mapper = mapper;

        }

        [HttpPost("adicionar-usuario")]
        public void adicionaraluno(JogoCategoria u)
        {
            JogoCategoria usuario = mapper.Map<JogoCategoria>(u);
            service.Adicionar(usuario);
        }

        [HttpGet("Listar-aluno")]
        public List<JogoCategoria> Listaraluno()
        {
            return service.Listar();
        }
        [HttpDelete("Remover-aluno")]
        public void Removeralunoaluno(int id)
        {
            service.Remover(id);
        }
        [HttpPut("editar-aluno")]
        public void editaraluno(JogoCategoria usuario)
        {
            service.editar(usuario);
        }
    }
}
