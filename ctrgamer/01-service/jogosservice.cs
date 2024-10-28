using ctrgamer._02_Repositorio;
using ctrgamer._02_Repositorio.Interfaces;
using ctrgamer._03_entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ctrgamer._01_service;

public class jogosservice
{
    IJogos repositorio { get; set; }

    public jogosservice(string connectionString)
    {
        repositorio=new Jogorepositorio(connectionString);
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

