using ctrgamer._01_service.Interfaces;
using ctrgamer._02_Repositorio;
using ctrgamer._02_Repositorio.Interfaces;
using ctrgamer._03_entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ctrgamer._01_service
{
    public class reevedendorservice_: IReevendedoservice
    {
        IRevendedorRepositor repositorio { get; set; }
        public reevedendorservice_(string connectionString)
        {
            repositorio = new revendedorrepositor(connectionString);
        }
        public void Adicionar(Reevendedor r)
        {
            repositorio.Adicionar(r);
        }

        public List<Reevendedor> Listar()
        {
            return repositorio.listar();
        }
        public void editar(Reevendedor r)
        {
            repositorio.editar(r);
        }
        public void Remover(int id)
        {

            repositorio.Remover(id);
        }

    }
}
