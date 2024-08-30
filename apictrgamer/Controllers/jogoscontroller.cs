using ctrgamer._01_service;
using ctrgamer._03_entidades;
using Microsoft.AspNetCore.Mvc;

namespace apictrgamer.Controllers;
[ApiController]
[Route("[controller]")]
public class jogoscontroller : ControllerBase
{
  
    
    

        jogosservice service;
        public jogoscontroller()
        {
            service = new jogosservice();

        }

        [HttpPost("adicionar-jogo")]
        public void adicionaraluno(Jogos u)
        {
            service.Adicionar(u);
        }

        [HttpGet("Listar-jogos")]
        public List<Jogos> Listaraluno()
        {



            return service.Listar();
        }
        [HttpDelete("Remover-jogos")]
        public void Removeralunoaluno(int id)
        {
            service.Remover(id);
        }
        [HttpPut("editar-aluno")]
        public void editaraluno(int id, Jogos jogos)
        {
            service.editar(id, jogos);
        }
    }
