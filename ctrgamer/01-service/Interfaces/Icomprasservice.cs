using ctrgamer._03_entidades;
using ctrgamer._03_entidades.DTO.Compra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ctrgamer._01_service.Interfaces
{
    public interface Icomprasservice
    {
        void Adicionar(Compra c);


        List<Compra> Listar();

        List<ReadCompraDTO> listarcompradto(int usuarioid);

        void editar(Compra c);

        void Remover(int id);
     
    }
}
