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
    public static List<usuario> listar()
    {
       
        {
            List<usuario> u = new List<usuario>();
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                var selectcommand = "select id, NOME, IDADE, CPF, EMAIL,SENHA from usuario";
                using (var command = new SQLiteCommand(selectcommand, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                           usuario s = new usuario();

                            s.id = int.Parse(reader["ID"].ToString());
                            s.Nome = reader["NOME"].ToString();
                            s.idade = int.Parse(reader["IDADE"].ToString());
                            s.cpf = double.Parse(reader["CPF"].ToString());
                            s.Email = reader["EMAIL"].ToString();
                            s.Senha = reader["SENHA"].ToString();
                            u.Add(s);



                        }
                    }

                }

                return u;
            }
        }
    }

    public void Remover(int id)
    {
        using (var connection = new SQLiteConnection(ConnectionString))
        {
            connection.Open();
            string deleteCommand = "DELETE FROM usuario WHERE ID =@ID";
            using (var command = new SQLiteCommand(deleteCommand, connection))
            {
                command.Parameters.AddWithValue("@ID", id);
                command.ExecuteNonQuery();
            }

        }
    }
    public void Editar(int id, usuario usuario)
    {
        using (var connection = new SQLiteConnection(ConnectionString))
        {
            connection.Open();
            string updatecommand = @"UPDATE usuario SET NOME=@NOME,IDADE=@IDADE,CPF=@CPF,EMAIL=@EMAIL,SENHA=@SENHA WHERE ID=@ID";
            using (var command = new SQLiteCommand(updatecommand, connection))
            {

                command.Parameters.AddWithValue("@ID", id);
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
