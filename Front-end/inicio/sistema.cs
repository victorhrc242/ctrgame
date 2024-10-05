using ctrgamer._03_entidades;
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
        private readonly JogoUC _JogoUC;
        public sistema(HttpClient cliente)
        {
                _UsuarioUC=new UsuarioUC(cliente);
            _JogoUC = new JogoUC(cliente);
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
            Console.WriteLine($"--------Bem vindo {usu.Username}----------\n" +
                $"1-Listar jogos\n" +
                $"2-Comprar jogos\n" +
                $"3-Carrinho\n" +
                $"4-Meus jogos\n" +
                $"5-Perfil");
            int resposta = -1;
                resposta = int.Parse(Console.ReadLine());
            if (resposta == 1)
            {
                ListarProdutos();
            }
        }
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
    }
}
