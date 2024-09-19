using AutoMapper;
using ctrgamer._02_Repositorio;
using ctrgamer._03_entidades;
using ctrgamer._03_entidades.DTO.carrinho;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ctrgamer._01_service;

public class carrinhoService
{


   

        carrinhoRepositorioi repositorio { get; set; }
    public carrinhoService(string connectionString,IMapper MAPPER)
    {
        repositorio = new carrinhoRepositorioi(connectionString,MAPPER);
    }
        public void Adicionar(Carrinho carrinho)
        {
            repositorio.Adicionar(carrinho);
        }

    public List<Reeadcarrinho> Listar()
    {
        return repositorio.listar();
    }
    public void editar(Carrinho c)
        {
            repositorio.editar(c );
        }
        public void Remover(int id)
        {

            repositorio.Remover(id);
        }


    }



