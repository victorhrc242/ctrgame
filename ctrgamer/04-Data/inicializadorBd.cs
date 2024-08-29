using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ctrgamer._04_Data;

public static class inicializadorBd
{
    private const string ConnectioString = "Data Source=Ctrgame.db";
    public static void iinicializador()
    {
        using (var connection = new SQLiteConnection(ConnectioString))
        {
            connection.Open();
            string commandoSQL = @" 
                CREATE TABLE IF NOT EXISTS usuario(                
                ID INTEGER PRIMARY KEY AUTOINCREMENT,
                NOME TEXT NOT NULL,
                EMAIL TEXT NOT NULL,
                SENHA TEXT NOT NULL,
                CPF DECIMAL NOT NULL,
                IDADE INTEGER NOT NULL
          
            );";
            using (var command = new SQLiteCommand(commandoSQL, connection))
            {
                command.ExecuteNonQuery();
            }

        }
    }
}
