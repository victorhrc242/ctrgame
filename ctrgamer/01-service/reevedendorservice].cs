using ctrgamer._01_service.Interfaces;
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
    public class reevedendorservice_: IReevendedoservice
    {
        private readonly IRevendedorRepositor repositorio;
        public reevedendorservice_(IRevendedorRepositor revendedorRepositor)
        {
            repositorio = revendedorRepositor;
        }
        public void Adicionar(Revendedore r)
        {
            repositorio.Adicionar(r);
        }

        public List<Revendedore> Listar()
        {
            return repositorio.listar();
        }
        public void editar(Revendedore r)
        {
            repositorio.editar(r);
        }
        public void Remover(int id)
        {

            repositorio.Remover(id);
        }
        public Revendedore FazerLogin(Usuariologindto usuarioLogin)
        {
            List<Revendedore> listUsuario = Listar();
            foreach (Revendedore usuario in listUsuario)
            {
                if (usuario.nome == usuarioLogin.Username
                    && usuario.senha == usuarioLogin.SENHA)
                {
                    return usuario;
                }
            }
            return null;
        }

    }
}
