using AutoMapper;
using ctrgamer._01_service.Interfaces;
using ctrgamer._02_Repositorio;
using ctrgamer._02_Repositorio.Interfaces;
using ctrgamer._03_entidades;
using ctrgamer._03_entidades.DTO.carrinho;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ctrgamer._01_service;

public class carrinhoService:ICarrinhoservice
{


   

        private readonly ICarrinhorepositor repositorio;
    public carrinhoService(ICarrinhorepositor carrinhorepositor,IMapper MAPPER)
    {
        repositorio = carrinhorepositor;
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
    public void FinalizarCompra(int carrinhoId)
    {
        repositorio.FinalizarCompra(carrinhoId);
    }
    public List<Reeadcarrinho> ObterCarrinhosFinalizadosPorUsuario(int usuarioId)
    {
        // Chama o repositório para obter os carrinhos finalizados
        var carrinhosFinalizados = repositorio.ListarCarrinhoFinalizadoDoUsuario(usuarioId);

        return carrinhosFinalizados;
    }


}



