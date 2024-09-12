using AutoMapper;
using ctrgamer._01_service;
using ctrgamer._03_entidades.DTO.usuario;
using ctrgamer._03_entidades;
using Microsoft.AspNetCore.Mvc;

namespace apictrgamer.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class avaliacaocontroller:ControllerBase
    {
        private readonly avaliacaosservice service;
        private readonly IMapper mapper;
        public avaliacaocontroller(IMapper _mapper, IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("DefaultConnection");
            service = new avaliacaosservice(connectionString);
            mapper = _mapper;

        }

        [HttpPost("adicionar-Avaliação")]
        public void adicionaraluno(Avaliacao u)
        {
            Avaliacao usuario = mapper.Map<Avaliacao>(u);
            service.Adicionar(usuario);
        }

        [HttpGet("Listar-Avaliações")]
        public List<Avaliacao> Listaraluno()
        {
            return service.Listar();
        }
        [HttpDelete("Remover-Avaliação")]
        public void Removeralunoaluno(int id)
        {
            service.Remover(id);
        }
        [HttpPut("editar-Avaliação")]
        public void editaraluno(Avaliacao usuario)
        {
            service.editar(usuario);
        }
    }
}
