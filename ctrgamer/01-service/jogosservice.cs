using ctrgamer._01_service.Interfaces;
using ctrgamer._02_Repositorio;
using ctrgamer._02_Repositorio.Interfaces;
using ctrgamer._03_entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ctrgamer._01_service;

public class jogosservice:IJogoservice
{
    private readonly IJogosReposytor repositorio;

    public jogosservice(IJogosReposytor jogosReposytor)
    {
        repositorio = jogosReposytor;
    }

    public void Adicionar(Jogo J)
    {
        repositorio.Adicionar(J);
    }

    public List<Jogo> Listar()
    {
        return repositorio.listar();
    }
    public void editar(Jogo J)
    {
        repositorio.editar(J);
    }
    public void Remover(int id)
    {

        repositorio.Remover(id);
    }


}

