using AutoMapper;  // Importa o AutoMapper, usado para mapear objetos entre camadas diferentes (por exemplo, de DTOs para entidades)
using ctrgamer._01_service;  // Namespace do serviço que contém a lógica de negócio para carrinhos de compras
using ctrgamer._01_service.Interfaces;  // Interfaces do serviço de carrinho
using ctrgamer._03_entidades;  // Contém as entidades de domínio (como Carrinho, etc.)
using ctrgamer._03_entidades.DTO.carrinho;  // Contém os DTOs relacionados aos carrinhos de compras
using Microsoft.AspNetCore.Mvc;  // Usado para criar controladores em ASP.NET Core

namespace apictrgamer.Controllers
{
    [ApiController]  // Define que a classe é um controlador de API, que processa requisições HTTP
    [Route("[controller]")]  // Define a rota base para os endpoints (o nome do controlador será usado na rota)
    public class carrinhoController : ControllerBase
    {
        private readonly ICarrinhoservice service;  // Interface para o serviço de carrinho, que contém a lógica de manipulação de dados
        private readonly IMapper mapper;  // AutoMapper, utilizado para mapear objetos entre DTOs e entidades

        public carrinhoController(IMapper _mapper, IConfiguration configuration, ICarrinhoservice carrinhoservice)
        {
            // Obtém a string de conexão a partir do arquivo de configuração (não é utilizado diretamente aqui)
            string connectionString = configuration.GetConnectionString("DefaultConnection");

            // Atribui as dependências passadas para as variáveis de instância
            service = carrinhoservice;
            mapper = _mapper;  // Atribui o parâmetro à variável de instância
        }

        /// <summary>
        /// Endpoint para adicionar um carrinho de compras
        /// </summary>
        /// <param name="carrinhoDTO">Objeto DTO com as informações do carrinho</param>
        [HttpPost("adicionar-carrinho")]  // Define a rota para adicionar um carrinho
        public IActionResult AdicionarCarrinho(Carrinho carrinhoDTO)
        {
            try
            {


                Carrinho carrinho = mapper.Map<Carrinho>(carrinhoDTO);

                // Chama o serviço para adicionar o carrinho
                service.Adicionar(carrinho);
                return Ok();
            }
            catch (Exception erro)
            {

                return BadRequest($"Ocorreu un erro ao adicionar aluno, o erro foi" +
                    $"\n{erro.Message}");
            }
        }

        /// <summary>
        /// Endpoint para listar todos os carrinhos de compras
        /// </summary>
        [HttpGet("Listar-compras")]  // Define a rota para listar todos os carrinhos
        public List<Carrinho> Listar()
        {
            // Chama o serviço para listar todos os carrinhos
            return service.Listar();
        }

        /// <summary>
        /// Endpoint para listar os carrinhos de compras de um usuário específico
        /// </summary>
        /// <param name="usuarioid">ID do usuário cujos carrinhos queremos listar</param>
        [HttpGet("Listar-carrinho")]  // Define a rota para listar carrinhos de um usuário
        public List<Reeadcarrinho> ListarCarrinhoDoUsuario(int usuarioid)
        {
            // Chama o serviço para listar os carrinhos de um usuário específico
            return service.listarcarrinhodousuario(usuarioid);
        }

        /// <summary>
        /// Endpoint para remover uma compra (carrinho de compras)
        /// </summary>
        /// <param name="id">ID do carrinho a ser removido</param>
        [HttpDelete("Remover-compras")]  // Define a rota para remover um carrinho
        public IActionResult RemoverCompra(int id)
        {
            try
            {


                service.Remover(id);
                return Ok();
            }
            catch (Exception erro)
            {

                return BadRequest($"Ocorreu un erro ao adicionar aluno, o erro foi" +
                    $"\n{erro.Message}");
            }
        }

        /// <summary>
        /// Endpoint para editar um carrinho de compras
        /// </summary>
        /// <param name="carrinho">Objeto contendo as novas informações do carrinho</param>
        [HttpPut("editar-compra")]  // Define a rota para editar um carrinho
        public IActionResult EditarCompra(Carrinho carrinho)
        {
            try
            {


                service.editar(carrinho);
                return Ok();
            }
            catch (Exception erro)
            {

                return BadRequest($"Ocorreu un erro ao adicionar aluno, o erro foi" +
                    $"\n{erro.Message}");
            }
        }

        /// <summary>
        /// Endpoint para finalizar uma compra
        /// </summary>
        /// <param name="carrinhoId">ID do carrinho a ser finalizado</param>
        [HttpPost("finalizar-compra")]  // Define a rota para finalizar uma compra
        public IActionResult FinalizarCompra(int carrinhoId)
        {
            try
            {
                service.FinalizarCompra(carrinhoId);
                return Ok();
            }
            catch (Exception erro)
            {

                return BadRequest($"Ocorreu un erro ao adicionar aluno, o erro foi" +
                    $"\n{erro.Message}");
            }
        }

        /// <summary>
        /// Endpoint para listar carrinhos finalizados de um usuário específico
        /// </summary>
        /// <param name="usuarioId">ID do usuário cujos carrinhos finalizados queremos listar</param>
        [HttpGet("usuario/{usuarioId}/finalizados")]  // Define a rota para listar os carrinhos finalizados de um usuário
        public IActionResult ListarCarrinhosFinalizados(int usuarioId)
        {
            try
            {
                var carrinhosFinalizados = service.ObterCarrinhosFinalizadosPorUsuario(usuarioId);
                return Ok();
            }
            catch (Exception erro)
            {

                return BadRequest($"Ocorreu un erro ao adicionar aluno, o erro foi" +
                    $"\n{erro.Message}");
            }



        }
    }
}
