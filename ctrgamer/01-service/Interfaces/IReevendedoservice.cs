using ctrgamer._03_entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ctrgamer._01_service.Interfaces
{
    public interface IReevendedoservice
    {
        public void Adicionar(Reevendedor r);


        public List<Reevendedor> Listar();

        public void editar(Reevendedor r);

        public void Remover(int id);
      


    }
}
