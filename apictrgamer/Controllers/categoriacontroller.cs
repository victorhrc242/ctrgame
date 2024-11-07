using AutoMapper;
using ctrgamer._01_service;
using ctrgamer._01_service.Interfaces;
using ctrgamer._03_entidades;
using Microsoft.AspNetCore.Mvc;


namespace apictrgamer.Controllers;

[ApiController]
[Route("[controller]")]
public class categoriacontroller:ControllerBase
{
    private readonly Icategoriasservice service;
    private readonly IMapper mapper;
    public categoriacontroller(IMapper _mapper, IConfiguration configuration,Icategoriasservice icategoriasservice)
    {
        string connectionString = configuration.GetConnectionString("DefaultConnection");
        service = icategoriasservice;
        mapper = _mapper;

    }

    [HttpPost("adicionar-usuario")]
    public void adicionaraluno(Categoria u)
    {
        Categoria usuario = mapper.Map<Categoria>(u);
        service.Adicionar(usuario);
    }

    [HttpGet("Listar-aluno")]
    public List<Categoria> Listaraluno()
    {
        return service.Listar();
    }
    [HttpDelete("Remover-aluno")]
    public void Removeralunoaluno(int id)
    {
        service.Remover(id);
    }
    [HttpPut("editar-aluno")]
    public void editaraluno(Categoria usuario)
    {
        service.editar(usuario);

    }
    }

