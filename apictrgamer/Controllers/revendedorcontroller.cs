using AutoMapper;
using ctrgamer._01_service;
using ctrgamer._03_entidades;
using Microsoft.AspNetCore.Mvc;

namespace apictrgamer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class revendedorcontroller:ControllerBase
    {
        private readonly reevedendorservice_ service;
        private readonly IMapper mapper;
        public revendedorcontroller(IMapper _mapper, IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("DefaultConnection");
            service = new reevedendorservice_(connectionString);
            mapper= _mapper;

        }

        [HttpPost("adicionar-Revenddedor")]
        public void adicionaraluno(Reevendedor u)
        {
            Reevendedor usuario = mapper.Map<Reevendedor>(u);
            service.Adicionar(usuario);
        }

        [HttpGet("Listar-Revendedores")]
        public List<Reevendedor> Listaraluno()
        {
            return service.Listar();
        }
        [HttpDelete("Remover-Revendedor")]
        public void Removeralunoaluno(int id)
        {
            service.Remover(id);
        }
        [HttpPut("editar-Revendedor")]
        public void editaraluno(Reevendedor usuario)
        {
            service.editar(usuario);
        }
    }
}
