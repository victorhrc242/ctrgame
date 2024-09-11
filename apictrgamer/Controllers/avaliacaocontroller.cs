﻿using AutoMapper;
using ctrgamer._01_service;
using ctrgamer._03_entidades.DTO.usuario;
using ctrgamer._03_entidades;
using Microsoft.AspNetCore.Mvc;

namespace apictrgamer.Controllers
{
<<<<<<< HEAD
    [ApiController]
    [Route("[controller]")]
=======
>>>>>>> parent of 0c7e8d7 (Revert "11/09/2024 codigo com erro")
    public class avaliacaocontroller:ControllerBase
    {
        private readonly avaliacaosservice service;
        private readonly IMapper mapper;
        public avaliacaocontroller(IMapper _mapper, IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("DefaultConnection");
            service = new avaliacaosservice(connectionString);
            _mapper = mapper;

        }

        [HttpPost("adicionar-usuario")]
        public void adicionaraluno(Avaliacao u)
        {
            Avaliacao usuario = mapper.Map<Avaliacao>(u);
            service.Adicionar(usuario);
        }

        [HttpGet("Listar-aluno")]
        public List<Avaliacao> Listaraluno()
        {
            return service.Listar();
        }
        [HttpDelete("Remover-aluno")]
        public void Removeralunoaluno(int id)
        {
            service.Remover(id);
        }
        [HttpPut("editar-aluno")]
        public void editaraluno(Avaliacao usuario)
        {
            service.editar(usuario);
        }
    }
}
