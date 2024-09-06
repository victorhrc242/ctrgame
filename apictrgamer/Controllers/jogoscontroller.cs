using ctrgamer._01_service;
using ctrgamer._03_entidades;
using Microsoft.AspNetCore.Mvc;

namespace apictrgamer.Controllers;
[ApiController]
[Route("[controller]")]
public class jogoscontroller : ControllerBase
{
  
    
    

      private readonly jogosservice service;
        public jogoscontroller(IConfiguration configuration)
        {
        string connectionString = configuration.GetConnectionString("DefaultConnection");
            service = new jogosservice(connectionString);

        }

        [HttpPost("adicionar-jogo")]
        public void adicionaraluno(Jogo u)
        {
            service.Adicionar(u);
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
