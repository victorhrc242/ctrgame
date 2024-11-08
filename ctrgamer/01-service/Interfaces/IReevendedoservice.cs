using ctrgamer._03_entidades;
using FrontEnd.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ctrgamer._01_service.Interfaces
{
    public interface IReevendedoservice
    {
        public void Adicionar(Revendedore r);


        public List<Revendedore> Listar();

        public void editar(Revendedore r);

        public void Remover(int id);
        public Revendedore FazerLogin(Usuariologindto usuarioLogin);
        


    }
}
