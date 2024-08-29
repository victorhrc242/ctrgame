using ctrgamer._03_entidades;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ctrgamer._02_Repositorio;

public class UsuarioRepositor
{

    public UsuarioRepositor()
    {



    }

    private const string ConnectionString = "Data Source=Ctrgame.db";


    public void Adicionar(usuario usuario)
    {

        using (var connection = new SQLiteConnection(ConnectionString))
        {

            connection.Open();
            string commandInsert = @" Insert into usuario(NOME,IDADE,EMAIL,CPF,SENHA) values(@NOME,@IDADE,@CPF,@EMAIL,@SENHA)";

           using (var command = new SQLiteCommand(commandInsert, connection))
           {
               command.Parameters.AddWithValue("@NOME", usuario.Nome);
               command.Parameters.AddWithValue("@IDADE", usuario.idade);
               command.Parameters.AddWithValue("@CPF", usuario.cpf);
               command.Parameters.AddWithValue("@EMAIL", usuario.Email);
               command.Parameters.AddWithValue("@SENHA", usuario.Senha);
                command.ExecuteNonQuery();
            }
        }


    }


}
