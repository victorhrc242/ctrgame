﻿using ctrgamer._01_service.Interfaces;
using ctrgamer._02_Repositorio;
using ctrgamer._02_Repositorio.Interfaces;
using ctrgamer._03_entidades;
using FrontEnd.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ctrgamer._01_service
{
    public class UsuarioService:IUsuarioservice
    {

        private readonly IUsuariorepositor repositorio;
        public UsuarioService(IUsuariorepositor usuariorepositor)
        {
            repositorio = usuariorepositor;
        }
            public void Adicionar(usuarioS usuario)
            {
                repositorio.Adicionar(usuario);
            }

        public List<usuarioS> Listar()
        {
           return repositorio.listar();
        }
        public void editar( usuarioS usuario)
        {
            repositorio.editar( usuario);
        }
        public void Remover(int id)
        {

            repositorio.Remover(id);
        }
        public usuarioS FazerLogin(Usuariologindto usuarioLogin)
        {
            List<usuarioS> listUsuario = Listar();
            foreach (usuarioS usuario in listUsuario)
            {
                if (usuario.Username == usuarioLogin.Username
                    && usuario.SENHA == usuarioLogin.SENHA)
                {
                    return usuario;
                }
            }
            return null;
        }

    }
}
