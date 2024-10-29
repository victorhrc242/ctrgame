using ctrgamer._03_entidades;
using FrontEnd.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ctrgamer._01_service.Interfaces
{
    public interface IUsuarioservice
    {
        void Adicionar(usuarioS usuario);
        List<usuarioS> Listar();
        void editar(usuarioS usuario);
        void Remover(int id);
        usuarioS FazerLogin(Usuariologindto usuarioLogin);

    }
}
