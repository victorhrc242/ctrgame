using AutoMapper;
using Core._01_Services;
using Core._03_Entidades;
using ctrgamer._01_service.Interfaces;
using ctrgamer._03_entidades.DTO.Compra;
using Microsoft.AspNetCore.Mvc;
using System.Data.SQLite;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]


    public class vendaController : ControllerBase
    {
        private readonly IVendaservice _service;
        private readonly IMapper _mapper;
        public vendaController(IConfiguration config, IMapper mapper,IVendaservice vendaservice)
        {

            _service = vendaservice;
            _mapper = mapper;
        }
        [HttpPost("adicionar-usuario")]
        public void AdicionarAluno(Venda venda)
        {
            _service.Adicionar(venda);
        }
     
        [HttpGet("listar-usuario")]
        public List<Venda> ListarAluno()
        {
            return _service.Listar();
        }
        [HttpPut("editar-usuario")]
       
        [HttpDelete("deletar-usuario")]
        public void DeletarUsuario(int id)
        {
            _service.Remover(id);
        }
        [HttpGet("listar-compra-do-usuario")]
        public List<Reavend> ListarCarrinhoDoUsuario(int usuarioId)
        {
       return  _service.ListarCarrinhoDoUsuario(usuarioId);
        }
    }
}
