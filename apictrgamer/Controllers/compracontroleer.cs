using AutoMapper;
using ctrgamer._01_service;
using ctrgamer._01_service.Interfaces;
using ctrgamer._03_entidades;
using ctrgamer._03_entidades.DTO.Compra;
using Microsoft.AspNetCore.Mvc;

namespace apictrgamer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class compracontroleer:ControllerBase
    {
        private readonly Icomprasservice service;
        private readonly IMapper mapper;
        public compracontroleer(IMapper _mapper, IConfiguration configuration,Icomprasservice icomprasservice)
        {
            string connectionString = configuration.GetConnectionString("DefaultConnection");
            service = icomprasservice;
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

        [HttpGet("Listar-compra")]
        public List<ReadCompraDTO> Listaraluno(int usuarioid)
        {
            return service.listarcompradto(usuarioid);
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
