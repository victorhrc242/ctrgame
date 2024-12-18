﻿using ctrgamer._01_service.Interfaces;
using ctrgamer._02_Repositorio;
using ctrgamer._02_Repositorio.Interfaces;
using ctrgamer._03_entidades;
using ctrgamer._03_entidades.DTO.Categorias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ctrgamer._01_service
{
    public class jogocategoriaservice:IJogocategoriaservice
    {
        private readonly IJogocategoriaRepositor repositorio;
        public jogocategoriaservice(IJogocategoriaRepositor jogocategoriaRepositor)
        {
            repositorio = jogocategoriaRepositor;
        }
        public void Adicionar(JogoCategoria j)
        {
            repositorio.Adicionar(j);
        }

        public List<JogoCategoria> Listar()
        {
            return repositorio.Listar();
        }
        public List<ReadCategoria> ListarJogoPorCategoria(int categoriaId)
        {
            return repositorio.ListarJogoPorCategoria(categoriaId);
        }
        public void editar(JogoCategoria j)
        {
            repositorio.editar(j);
        }
        public void Remover(int id)
        {

            repositorio.Remover(id);
        }

    }
}
