using AutoMapper;  // Importa o AutoMapper, utilizado para mapear objetos entre DTOs e entidades
using ctrgamer._01_service;  // Namespace do serviço que contém a lógica de negócio para revendedores
using ctrgamer._01_service.Interfaces;  // Interfaces do serviço de revendedor
using ctrgamer._03_entidades;  // Contém as entidades de domínio (como Revendedore, etc.)
using Microsoft.AspNetCore.Mvc;  // Usado para criar controladores em ASP.NET Core

namespace apictrgamer.Controllers
{
    // Define o controlador da API para revendedores
    [ApiController]  // Indica que a classe é um controlador de API que processa requisições HTTP
    [Route("[controller]")]  // Define a rota base para o controlador (o nome do controlador será usado como parte da rota)
    public class revendedorcontroller : ControllerBase
    {
        // Declaração das dependências necessárias
        private readonly IReevendedoservice service;  // Interface do serviço de revendedores, que contém a lógica de manipulação de dados
        private readonly IMapper mapper;  // AutoMapper, utilizado para mapear entre objetos DTO e entidades

        // Construtor da classe, responsável pela injeção de dependências
        public revendedorcontroller(IMapper _mapper, IConfiguration configuration, IReevendedoservice reevedendorservice)
        {
            // Atribui as dependências passadas para as variáveis de instância
            service = reevedendorservice;
            mapper = _mapper;  // Atribui o parâmetro à variável de instância
        }

        /// <summary>
        /// Endpoint para adicionar um revendedor
        /// </summary>
        /// <param name="u">Objeto DTO com as informações do revendedor</param>
        [HttpPost("adicionar-Revenddedor")]  // Define a rota para adicionar um revendedor
        public IActionResult adicionaraluno(Revendedore u)
        {
            try
            {

                Revendedore usuario = mapper.Map<Revendedore>(u);
                service.Adicionar(usuario);
                return Ok();
            }
            catch (Exception erro)
            {

                return BadRequest($"Ocorreu un erro ao adicionar aluno, o erro foi" +
                    $"\n{erro.Message}");
            }
        }

        /// <summary>
        /// Endpoint para listar todos os revendedores
        /// </summary>
        [HttpGet("Listar-Revendedores")]  // Define a rota para listar todos os revendedores
        public List<Revendedore> Listaraluno()
        {
            // Chama o serviço para listar todos os revendedores
            return service.Listar();
        }

        /// <summary>
        /// Endpoint para remover um revendedor
        /// </summary>
        /// <param name="id">ID do revendedor a ser removido</param>
        [HttpDelete("Remover-Revendedor")]  // Define a rota para remover um revendedor
        public IActionResult Removeralunoaluno(int id)
        {
            try
            {
                // Chama o serviço para remover o revendedor pelo ID
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
        /// Endpoint para editar um revendedor
        /// </summary>
        /// <param name="usuario">Objeto contendo as novas informações do revendedor</param>
        [HttpPut("editar-Revendedor")]  // Define a rota para editar um revendedor
        public IActionResult editaraluno(Revendedore usuario)
        {
            try
            {


                // Chama o serviço para editar as informações do revendedor
                service.editar(usuario);
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
