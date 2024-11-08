using AutoMapper;
using ctrgamer._01_service;
using ctrgamer._01_service.Interfaces;
using ctrgamer._03_entidades;
using Microsoft.AspNetCore.Mvc;

namespace apictrgamer.Controllers;
[ApiController]
[Route("[controller]")]
public class jogoscontroller : ControllerBase
{
  
    
    

      private readonly IJogoservice service;
    private readonly IMapper mapper;
        public jogoscontroller(IMapper _mapper, IConfiguration configuration,IJogoservice jogoservice)
        {
        string connectionString = configuration.GetConnectionString("DefaultConnection");
        service = jogoservice;
        mapper = _mapper;
        }

        [HttpPost("adicionar-jogo")]
        public void adicionaraluno(Jogo j)
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
        [HttpPut("editar-jogo")]
        public void editaraluno(Jogo J)
        {
            service.editar(J);
        }
    }
