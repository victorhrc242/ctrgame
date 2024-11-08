using ctrgamer._03_entidades;
using Front_End_ADM.UsuarioU;
using FrontEnd.DTOS;

namespace Front_End_ADM.Inicio
{
    public class Sistema
    {
        private static usuarioS usuariologado;
        private readonly UsuarioUC _UsuarioUC;
        public Sistema(HttpClient _client)
        {
            _UsuarioUC = new UsuarioUC(_client);
        }
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
                    Usuariologindto usudto = new Usuariologindto();
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


            return int.Parse(Console.ReadLine());
        }
        public void exibirmenuprincipal(Usuariologindto usu)
        {
            Console.WriteLine($"--------Bem vindo {usuariologado.Username}----------\n" +
                $"1-Listar jogos\n" +
                $"2-Carrinho\n" +
                $"3-Meus jogos\n" +
                $"4-Perfil");
            int resposta = -1;
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
            usuario.CPF = double.Parse(Console.ReadLine());
            Console.WriteLine("Digite Sua idade: ");
            usuario.IDADE = int.Parse(Console.ReadLine());
            return usuario;
        }
    }
}
