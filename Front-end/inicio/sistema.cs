using ctrgamer._03_entidades;
using ctrgamer._03_entidades.DTO.carrinho;
using Front_end.PastaUC;
using FrontEnd.DTOS;
using FrontEnd.PastaUC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontEnd.inicio
{
    public class sistema
    {
        //chamar classe//
        private static usuarioS usuariologado;
        private readonly UsuarioUC _UsuarioUC;
        private readonly CarrinhoUC _CarrinhoUC;
        private readonly JogoUC _JogoUC;
        public sistema(HttpClient cliente)
        {
                _UsuarioUC=new UsuarioUC(cliente);
            _JogoUC = new JogoUC(cliente);
            _CarrinhoUC=new CarrinhoUC(cliente);
        }
        //iniciar sistema//
        public void iniciarsistema()
        {
            int resposta = -1;
            while (resposta != 0)
            {
                if (usuariologado == null)
                {
                    resposta = exibirmenulogin();
                    if (resposta == 1)
                    {
                        FazerLogin();
                    }
                    if (resposta == 2)
                    {
                        usuarioS usuario = CriarUsuario();
                        _UsuarioUC.Cadastrarusuario(usuario);
                        Console.WriteLine("Usuário cadastrado com sucesso");
                    }
                }
                else
                {
                    Usuariologindto usudto= new Usuariologindto();
                    exibirmenuprincipal(usudto);
                }
            }
        }
        //menus//
        public int exibirmenulogin()
        {
            Console.WriteLine($"---------Bem vindo-----------\n" +
                              $"1-Fazer Login\n" +
                              $"2-Cadastra Usuario");
            

            return int.Parse( Console.ReadLine() );
        }
        public void exibirmenuprincipal(Usuariologindto usu)
        {
            Console.WriteLine($"--------Bem vindo {usuariologado.Username}----------\n" +
                $"1-Listar jogos\n" +
                $"2-Carrinho\n" +
                $"3-Meus jogos\n" +
                $"4-Perfil");
            int resposta = -1;
            resposta = int.Parse(Console.ReadLine());
            if (resposta == 1)
            {
                int opcao = 1;
                while (opcao == 1)
                {
                    //Listar Produto
                    ListarProdutos();
                    //Escolher Produto
                    Console.WriteLine("Digite os jogos que deseja comprar:");
                    int produtoId = int.Parse(Console.ReadLine());
                    Carrinho c = new Carrinho();
                    c.JogoId = produtoId;
                    c.usuarioid = usuariologado.ID;
                    _CarrinhoUC.CadastrarCarrinho(c);

                    Console.WriteLine("Escolha a opção: " +
                        "\n 1- Escolher mais produtos" +
                        "\n 2- Finalizar compra");
                    opcao = int.Parse(Console.ReadLine());
                }
            }
            if (resposta == 2)
            {
                List<Reeadcarrinho> carrinhosDTO = _CarrinhoUC.ListarCarrinhoUsuarioLogado(usuariologado.ID);
                foreach (Reeadcarrinho car in carrinhosDTO)
                {
                    Console.WriteLine(car.ToString());
                }


            }
            if(resposta == 3)
            {
                

            }
            if (resposta == 4)
            {
                listarusuario();
            }
        }

        //private void FinalizarVenda(int usuarioid)
        //{
        //    Compra c = CriarVenda(usuarioid);
        //    c = _vendaUC.CadastrarVenda(v);
        //    ReadVendaReciboDTO recibo = _vendaUC.BuscarVendaPorId(v.Id);
        //    Console.WriteLine(recibo.ToString());
        //}

        //private Compra CriarVenda(int usuarioid)
        //{
        //    Compra v = new Compra();

        //    Console.WriteLine("Digite a forma de pagamento:" +
        //        "\n 1- PIX" +
        //        "\n 2- Debito" +
        //        "\n 3- Crédito");

        //    int opcaoSelecionada = int.Parse(Console.ReadLine());
        //    DateTime dateTime;
        //    v.tipodepagamento = v.GetMetodoPagamentoById(opcaoSelecionada);
        //    v.usuarioid = usuarioid;
        //    v.ValorFinal= SomaValores();
        //    v.Datacompr = dateTime;

        //    return v;
        //}
        //public double SomaValores()
        //{
        //    double valor = 0;
        //    List<Reeadcarrinho> carrinhosDTO = _CarrinhoUC.ListarCarrinhoUsuarioLogado(usuariologado.ID);
        //    foreach (Reeadcarrinho car in carrinhosDTO)
        //    {
        //        valor += car.jogo.preco;
        //    }
        //    return valor;
        //}

        //public void ListarMeusJogos()
        //{
        //    List<Compra> compras = _vendaUC.ListarComprasPorUsuario(usuariologado.ID);
        //    foreach (Compra compra in compras)
        //    {
        //        Console.WriteLine($"Compra ID: {compra.Id}, Data: {compra.Datacompr}, Valor: {compra.ValorFinal}");
        //        // Adicione mais detalhes dos jogos comprados, se necessário
        //    }
        //}
        //opçoes//
        public usuarioS CriarUsuario()
        {
           usuarioS usuario = new usuarioS();
            Console.WriteLine("Digite seu nome: ");
            usuario.NOME = Console.ReadLine();
            Console.WriteLine("Digite seu username: ");
            usuario.Username = Console.ReadLine();
            Console.WriteLine("Digite seu senha: ");
            usuario.SENHA = Console.ReadLine();
            Console.WriteLine("Digite seu email: ");
            usuario.EMAIL = Console.ReadLine();
            Console.WriteLine("Digite seu CPF: ");
            usuario.CPF =double.Parse( Console.ReadLine());
            Console.WriteLine("Digite Sua idade: ");
            usuario.IDADE =int.Parse( Console.ReadLine());
            return usuario;
        }
        public void FazerLogin()
        {
            Console.WriteLine("Digite seu username: ");
            string username = Console.ReadLine();
            Console.WriteLine("Digite sua senha: ");
            string senha = Console.ReadLine();
            Usuariologindto usuDTO = new Usuariologindto()
            {
                Username = username,
                SENHA = senha
            };
            usuarioS usuario = _UsuarioUC.FazreLogin(usuDTO);
            if (usuario == null)
            {
                Console.WriteLine("Usuário ou senha inválidos!!!");
            }
            usuariologado = usuario;
        }
        private void ListarProdutos()
        {
            List<Jogo> produtos = _JogoUC.ListarProduto();
            foreach (Jogo u in produtos)
            {
                Console.WriteLine(u.ToString());
            }
        }
        private void listarusuario()
        {
            List<usuarioS> usuario =_UsuarioUC.ListarUsuarios();
            foreach (usuarioS u in usuario)
            {
                Console.WriteLine(u.ToString());
            }
        }
    }
}
