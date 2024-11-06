using Core._03_Entidades;
using ctrgamer._02_Repositorio.Interfaces;
using ctrgamer._03_entidades.DTO.Compra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ctrgamer._01_service.Interfaces
{
    public interface IVendaservice
    {


        public void Adicionar(Venda usuario);


        public void Remover(int id);


        public List<Venda> Listar();
        public Venda BuscarTimePorId(int id);
        public List<Reavend> ListarCarrinhoDoUsuario(int usuarioId);
      
    }
}
