using ctrgamer._02_Repositorio;
using ctrgamer._03_entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ctrgamer._01_service;

public class jogosservice
{
    Jogorepositorio repositorio = new Jogorepositorio();

    public void Adicionar(Jogos jogos)
    {
        repositorio.Adicionar(jogos);
    }

    public List<Jogos> Listar()
    {
        return Jogorepositorio.listar();
    }
    public void editar(int id, Jogos jogos)
    {
        repositorio.Editar(id, jogos);
    }
    public void Remover(int id)
    {

        repositorio.Remover(id);
    }


}

