using ctrgamer._03_entidades;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ctrgamer._02_Repositorio;

public class Jogorepositorio
{

    public Jogorepositorio()
    {



    }

    private const string ConnectionString = "Data Source=Ctrgame.db";


    public void Adicionar(Jogos j)
    {
        using (var connection = new SQLiteConnection(ConnectionString))
        {
            connection.Open();
            string commandInsert = @" Insert into  JOGO(NOME,DESCRICAO,PRECO,DATA) values(@NOME,@DESCRICAO,@PRECO,@DATA)";

            using (var command = new SQLiteCommand(commandInsert, connection))
            {
                command.Parameters.AddWithValue("@NOME", j.Nome);
                command.Parameters.AddWithValue("@DESCRICAO", j.Descricao);
                command.Parameters.AddWithValue("@PRECO", j.preco);
                command.Parameters.AddWithValue("@DATA", j.DataDeLancamento);
                command.ExecuteNonQuery();
            }
        }
    }
    public static List<Jogos> listar()
    {

        {
            List<Jogos> j = new List<Jogos>();
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                var selectcommand = "select id, NOME, DESCRICAO, PRECO, DATA from JOGO";
                using (var command = new SQLiteCommand(selectcommand, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Jogos o = new Jogos();

                            o.id = int.Parse(reader["ID"].ToString());
                            o.Nome = reader["NOME"].ToString();
                            o.Descricao = (reader["descricao"].ToString());
                            o.preco = double.Parse(reader["preco"].ToString());
                            o.DataDeLancamento =DateTime.Parse( reader["data"].ToString());                            
                            j.Add(o);



                        }
                    }

                }

                return j;
            }
        }
    }

    public void Remover(int id)
    {
        using (var connection = new SQLiteConnection(ConnectionString))
        {
            connection.Open();
            string deleteCommand = "DELETE FROM JOGO WHERE ID =@ID";
            using (var command = new SQLiteCommand(deleteCommand, connection))
            {
                command.Parameters.AddWithValue("@ID", id);
                command.ExecuteNonQuery();
            }

        }
    }
    public void Editar(int id, Jogos jogos)
    {
        using (var connection = new SQLiteConnection(ConnectionString))
        {
            connection.Open();
            string updatecommand = @"UPDATE JOGO SET NOME=@NOME,DESCRICAO=@DESCRICAO,PRECO=@PRECO,DATA=@DATA WHERE ID=@ID";
            using (var command = new SQLiteCommand(updatecommand, connection))
            {

                command.Parameters.AddWithValue("@ID", id);
                command.Parameters.AddWithValue("@NOME", jogos.Nome);
                command.Parameters.AddWithValue("@DESCRICAO", jogos.Descricao);
                command.Parameters.AddWithValue("@PRECO", jogos.preco);
                command.Parameters.AddWithValue("@DATA", jogos.DataDeLancamento);
                command.ExecuteNonQuery();
            }
        }
    }

}
