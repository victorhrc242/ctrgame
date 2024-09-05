using ctrgamer._02_Repositorio;
using ctrgamer._03_entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ctrgamer._01_service;

public class carrinhoService
{


   

        carrinhoRepositorioi repositorio { get; set; }
    public carrinhoService(string connectionString)
    {
        repositorio = new carrinhoRepositorioi(connectionString);
    }
        public void Adicionar(Carrinho carrinho)
        {
            repositorio.Adicionar(carrinho);
        }

    public List<Carrinho> Listar()
    {
        return repositorio.listar();
    }
    public void editar(int id, Carrinho carrinho)
        {
            repositorio.Editar(id, carrinho);
        }
        public void Remover(int id)
        {

            repositorio.Remover(id);
        }


    }



