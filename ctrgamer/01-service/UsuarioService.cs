﻿using ctrgamer._02_Repositorio;
using ctrgamer._03_entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ctrgamer._01_service
{
    public class UsuarioService
    {

      UsuarioRepositor repositorio=new UsuarioRepositor();
        
            public void Adicionar(usuario usuario)
            {
                repositorio.Adicionar(usuario);
            }

        public List<usuario> Listar()
        {
            return UsuarioRepositor.listar();
        }
        public void editar(int id, usuario usuario)
        {
            repositorio.Editar(id, usuario);
        }
        public void Remover(int id)
        {

            repositorio.Remover(id);
        }


    }
}
