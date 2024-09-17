using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace ctrgamer._04_Data
{
    public static class InicializadorBd
    {
        private const string ConnectionString = "Data Source=Ctrgame.db";

        public static void Inicializador()
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                string commandoSQL = @"
                    CREATE TABLE IF NOT EXISTS usuarios (
                        ID INTEGER PRIMARY KEY AUTOINCREMENT,
                        NOME TEXT NOT NULL,
                        EMAIL TEXT NOT NULL,
                        SENHA TEXT NOT NULL,
                        CPF TEXT NOT NULL,
                        IDADE INTEGER NOT NULL
                    );";

                using (var command = new SQLiteCommand(commandoSQL, connection))
                {
                    command.ExecuteNonQuery();
                }
                commandoSQL = @"
                    CREATE TABLE IF NOT EXISTS JOGOS (
                        ID INTEGER PRIMARY KEY AUTOINCREMENT,
                        NOME TEXT NOT NULL,
                        DESCRICAO TEXT NOT NULL,
                        PRECO REAL NOT NULL,
                        DATA DATETIME NOT NULL
                    );";

                using (var command = new SQLiteCommand(commandoSQL, connection))
                {
                    command.ExecuteNonQuery();
                }
                commandoSQL = @"
                    CREATE TABLE IF NOT EXISTS carrinhos (
                        ID INTEGER PRIMARY KEY AUTOINCREMENT,
                        jogoid INTEGER,
                        pagamentoid INTEGER,
                        usuarioid INTEGER
                    );";

                using (var command = new SQLiteCommand(commandoSQL, connection))
                {
                    command.ExecuteNonQuery();
                }
                commandoSQL = @"
                    CREATE TABLE IF NOT EXISTS Categorias (
                        id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Nome TEXT,
                        Descricao TEXT,
                        jogos TEXT
                    );";

                using (var command = new SQLiteCommand(commandoSQL, connection))
                {
                    command.ExecuteNonQuery();
                }
                commandoSQL = @"
                    CREATE TABLE IF NOT EXISTS Compras (
id INTEGER PRIMARY KEY AUTOINCREMENT,
                        usuarioid INTEGER,
                        Datacompra DATETIME NOT NULL,
                        total REAL NOT NULL,
                        itens TEXT
                    );";

                using (var command = new SQLiteCommand(commandoSQL, connection))
                {
                    command.ExecuteNonQuery();
                }
                commandoSQL = @"
                    CREATE TABLE IF NOT EXISTS itemCompras (
id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Compraid INTEGER,
                        jogoid INTEGER,
                        quantidade INTEGER NOT NULL,
                        precounutario DECIMAL NOT NULL,
                        totalitem REAL NOT NULL
                    );";

                using (var command = new SQLiteCommand(commandoSQL, connection))
                {
                    command.ExecuteNonQuery();
                }
                commandoSQL = @"
                    CREATE TABLE IF NOT EXISTS jogoCategorias (
id INTEGER PRIMARY KEY AUTOINCREMENT,
                        jogoid INTEGER,
                        categoriaid INTEGER
                    );";

                using (var command = new SQLiteCommand(commandoSQL, connection))
                {
                    command.ExecuteNonQuery();
                }
                commandoSQL = @"
                    CREATE TABLE IF NOT EXISTS Pagamentos (
id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Compraid INTEGER,
                        TipoPagamento TEXT,
                        status TEXT
                    );";

                using (var command = new SQLiteCommand(commandoSQL, connection))
                {
                    command.ExecuteNonQuery();
                }
                commandoSQL = @"
                    CREATE TABLE IF NOT EXISTS Reevendedors (
id INTEGER PRIMARY KEY AUTOINCREMENT,                        
                        Nome TEXT,
                        Endereco TEXT,
                        Telefone TEXT,
                        Email TEXT
                    );";

                using (var command = new SQLiteCommand(commandoSQL, connection))
                {
                    command.ExecuteNonQuery();
                }
                using (var command = new SQLiteCommand(commandoSQL, connection))
                {
                    command.ExecuteNonQuery();
                }
                commandoSQL = @"
                    CREATE TABLE IF NOT EXISTS Avaliacaos (
id INTEGER PRIMARY KEY AUTOINCREMENT,
                     jogoid INTEGER,
                     usuarioid INTEGER,
                     nota DECIMAL,
                     Comentario TEXT
                    );";

                using (var command = new SQLiteCommand(commandoSQL, connection))
                {
                    command.ExecuteNonQuery();
                }
            }

        }
    }
}
