using ctrgamer._03_entidades.DTO.Compra;
using ctrgamer._03_entidades;
using ctrgamer._01_service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace apictrgamer.Controllers
{
    public class VendaController : ControllerBase
    {
        private readonly IVendaservice vendasevice;  


        public VendaController(IVendaservice vendaservice, IConfiguration configuration)
        {
            vendasevice = vendaservice;  
        }

        /// <summary>
        /// Adiciona uma nova venda ao sistema.
        /// </summary>
        /// <param name="carrinho">Objeto do tipo Venda contendo os dados da venda a ser adicionada.</param>
        [HttpPost("adicinar-venda")]
        public void Adicionar(Venda carrinho)
        {
            vendasevice.Adicionar(carrinho);  // Chama o serviço para adicionar a venda
        }

        /// <summary>
        /// Lista todas as vendas registradas no sistema.
        /// </summary>
        /// <returns>Lista de objetos do tipo Venda contendo todas as vendas registradas.</returns>
        [HttpGet("listar-venda")]
        public List<Venda> Listar()
        {
            return vendasevice.Listar();  // Chama o serviço para listar todas as vendas
        }

        /// <summary>
        /// Lista as vendas de um usuário específico, com base no ID do usuário.
        /// </summary>
        /// <param name="usuarioId">ID do usuário cujas vendas serão listadas.</param>
        /// <returns>Lista de objetos ReadvendaDTO com as informações das vendas do usuário.</returns>
        [HttpGet("listar-venda-por-usuario")]
        public List<ReadvendaDTO> ListarCarrinhoDoUsuario(int usuarioId)
        {
            return vendasevice.ListarCarrinhoDoUsuario(usuarioId);  // Chama o serviço para listar as vendas de um usuário específico
        }

        /// <summary>
        /// Deleta um registro de venda do sistema com base no ID da venda.
        /// </summary>
        /// <param name="id">ID da venda a ser removida.</param>
        [HttpDelete("deleta-venda")]
        public void Remover(int id)
        {
            vendasevice.Remover(id);  // Chama o serviço para remover a venda com o ID especificado
        }

        /// <summary>
        /// Edita os dados de uma venda existente no sistema.
        /// </summary>
        /// <param name="c">Objeto do tipo Venda contendo os dados atualizados da venda.</param>
        [HttpPut("editar-venda")]
        public void editar(Venda c)
        {
            vendasevice.editar(c);  // Chama o serviço para editar a venda com os dados fornecidos
        }
    }
}
