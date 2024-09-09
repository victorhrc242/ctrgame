using AutoMapper;
using ctrgamer._01_service;
using ctrgamer._03_entidades;
using ctrgamer._03_entidades.DTO.jogo;
using Microsoft.AspNetCore.Mvc;

namespace apictrgamer.Controllers;
[ApiController]
[Route("[controller]")]
public class jogoscontroller : ControllerBase
{
  
    
    

      private readonly jogosservice service;
    private readonly IMapper mapper;
        public jogoscontroller(IMapper _mapper, IConfiguration configuration)
        {
        string connectionString = configuration.GetConnectionString("DefaultConnection");
            service = new jogosservice(connectionString);
        _mapper=mapper;
        }

        [HttpPost("adicionar-jogo")]
        public void adicionaraluno(createjogo j)
        {
        Jogo jogo= mapper.Map<Jogo>(j);
            service.Adicionar(jogo);
        }

        [HttpGet("Listar-jogos")]
        public List<Jogo> Listaraluno()
        {



            return service.Listar();
        }
        [HttpDelete("Remover-jogos")]
        public void Removeralunoaluno(int id)
        {
            service.Remover(id);
        }
        [HttpPut("editar-aluno")]
        public void editaraluno(Jogo J)
        {
            service.editar(J);
        }
    }
