﻿using ctrgamer._02_Repositorio;
using ctrgamer._03_entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ctrgamer._01_service
{
    public class avaliacaosservice
    {
        AvaliacaRepositor repositorio { get; set; }
        public avaliacaosservice(string connectionString)
        {
            repositorio = new AvaliacaRepositor(connectionString);
        }
        public void Adicionar(Avaliacao a)
        {
            repositorio.Adicionar(a);
        }

        public List<Avaliacao> Listar()
        {
            return repositorio.listar();
        }
        public void editar(Avaliacao a)
        {
            repositorio.editar(a);
        }
        public void Remover(int id)
        {

            repositorio.Remover(id);
        }

    }
}
