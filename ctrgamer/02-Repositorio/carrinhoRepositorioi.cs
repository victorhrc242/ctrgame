using ctrgamer._03_entidades;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ctrgamer._02_Repositorio
{
    public class carrinhoRepositorioi
    {
        private  readonly  string ConnectionString;
        public  carrinhoRepositorioi ( string  connectionString)
        {

            ConnectionString = connectionString;

        }

        


        public void Adicionar(Carrinho carrinho)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                string commandInsert = @" Insert into carrinho(NOMEJOGO,DATA,VALORTOTAL,FORMALDEPAGAMENTO) values(@NOMEJOGO,@DATA,@VALORTOTAL,@FORMALDEPAGAMENTO)";

                using (var command = new SQLiteCommand(commandInsert, connection))
                {
                    command.Parameters.AddWithValue("@NOMEJOGO", carrinho.nomejogo);
                    command.Parameters.AddWithValue("@DATA", carrinho.Data);
                    command.Parameters.AddWithValue("@VALORTOTAL", carrinho.ValorTotal);
                    command.Parameters.AddWithValue("@FORMALDEPAGAMENTO", carrinho.Formapagamento);   
                    command.ExecuteNonQuery();
                }
            }
        }
        public   List<Carrinho> listar()
        {

            {
                List<Carrinho> c = new List<Carrinho>();
                using (var connection = new SQLiteConnection(ConnectionString))
                {
                    connection.Open();
                    var selectcommand = "select ID, NOMEJOGO,DATA,VALORTOTAL,FORMALDEPAGAMENTO from carrinho";
                    using (var command = new SQLiteCommand(selectcommand, connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Carrinho n = new Carrinho();

                                n.id = int.Parse(reader["ID"].ToString());
                                n.nomejogo = reader["NOMEJOGO"].ToString();
                                n.Data = DateTime.Parse(reader["DATA"].ToString());
                                n.ValorTotal = double.Parse(reader["VALORTOTAL"].ToString());
                                n.Formapagamento = reader["FORMALDEPAGAMENTO"].ToString();
                                c.Add(n);



                            }
                        }

                    }

                    return c;
                }
            }
        }

        public void Remover(int id)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                string deleteCommand = "DELETE FROM carrinho WHERE ID =@ID";
                using (var command = new SQLiteCommand(deleteCommand, connection))
                {
                    command.Parameters.AddWithValue("@ID", id);
                    command.ExecuteNonQuery();
                }

            }
        }
        public void Editar(int id, Carrinho carrinho)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                string updatecommand = @"UPDATE carrinho SET FORMALDEPAGAMENTO=@FORMALDEPAGAMENTO WHERE ID=@ID";
                using (var command = new SQLiteCommand(updatecommand, connection))
                {

                    command.Parameters.AddWithValue("@ID", carrinho.id);

                    command.Parameters.AddWithValue("@FORMALDEPAGAMENTOL",carrinho.Formapagamento );

                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
