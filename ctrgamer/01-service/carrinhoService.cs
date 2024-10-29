using AutoMapper;
using ctrgamer._01_service.Interfaces;
using ctrgamer._02_Repositorio;
using ctrgamer._02_Repositorio.Interfaces;
using ctrgamer._03_entidades;
using ctrgamer._03_entidades.DTO.carrinho;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ctrgamer._01_service;

public class carrinhoService:ICarrinhoservice
{


   

        ICarrinhorepositor repositorio { get; set; }
    public carrinhoService(string connectionString,IMapper MAPPER)
    {
        repositorio = new carrinhoRepositorioi(connectionString);
    }
        public void Adicionar(Carrinho carrinho)
        {
            repositorio.Adicionar(carrinho);
        }

    public List<Carrinho> Listar()
    {
        return repositorio.Listar();
    }
    public List<Reeadcarrinho> listarcarrinhodousuario(int usuarioid)
    {
        return repositorio.ListarCarrinhoDoUsuario(usuarioid);
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



