using ctrgamer._03_entidades;
using FrontEnd.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Frootend
{
    public class Sistema
    {
        public static usuarioS usuariologado { get; set; }
        public static UsuarioUc usuarioUc;
        public Sistema(HttpClient cliente)
        {
            usuarioUc = new UsuarioUc(cliente);
        }


        public void inicirasistema()
        {
            int resposta = -1;
            while (resposta != 0)
            {
                if (usuariologado == null)
                {
                    resposta = exibirmenu();
                    if (resposta == 1)
                    {

                        FazerLogin();
                    }
                    if (resposta == 2)
                    {

                        usuarioS usuario = CadastrarUsuario();
                        usuarioUc.CadastrarUsuario(usuario);
                        Console.WriteLine("Usuário cadastrado com sucesso");
                    }
                }

            }

        }
        public int exibirmenu()
        {
            Console.WriteLine("---------------Menu de Login---------------\n" +
                              "1-Fazer-login\n" +
                              "2-Cadastrar-Usuario");
         return  int.Parse(Console.ReadLine());
        }
        public void FazerLogin()
        {
            Console.WriteLine("Digite seu username: ");
            string username = Console.ReadLine();
            Console.WriteLine("Digite sua senha: ");
            string senha = Console.ReadLine();
            Usuariologindto usuDTO = new Usuariologindto
            {
                Username = username,
                SENHA = senha
            };
            usuarioS usuario = usuarioUc.FazerLogin(usuDTO);
            if (usuario == null)
            {
                Console.WriteLine("Usuário ou senha inválidos!!!");
            }
            usuariologado = usuario;
            Console.WriteLine("Usuario Logado com Sucesso");
        }
        public usuarioS CadastrarUsuario()
        {
            usuarioS usuario= new usuarioS();
            Console.WriteLine("Digite seu nome: ");
            usuario.NOME = Console.ReadLine();
            Console.WriteLine("Digite seu username: ");
            usuario.Username = Console.ReadLine();
            Console.WriteLine("Digite seu senha: ");
            usuario.SENHA = Console.ReadLine();
            Console.WriteLine("Digite seu email: ");
            usuario.EMAIL = Console.ReadLine();
            Console.WriteLine("Digite sua idade: ");
            usuario.IDADE = int.Parse(Console.ReadLine());
            return usuario;
        }
    }
}
