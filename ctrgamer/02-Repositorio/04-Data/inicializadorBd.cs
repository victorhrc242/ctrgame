using System;
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

                // Criar tabela de usuários
                string commandoSQL = @"
                    CREATE TABLE IF NOT EXISTS usuarioSs (
                        ID INTEGER PRIMARY KEY AUTOINCREMENT,
                        NOME TEXT NOT NULL,
                        Username TEXT NOT NULL,
                        EMAIL TEXT NOT NULL,
                        SENHA TEXT NOT NULL,
                        CPF TEXT NOT NULL,
                        IDADE INTEGER NOT NULL
                    );";
                ExecuteCommand(connection, commandoSQL);

                // Criar tabela de jogos
                commandoSQL = @"
                    CREATE TABLE IF NOT EXISTS JOGOS (
                        ID INTEGER PRIMARY KEY AUTOINCREMENT,
                        NOME TEXT NOT NULL,
                        DESCRICAO TEXT NOT NULL,
                        PRECO REAL NOT NULL,
                        DATA DATETIME NOT NULL
                    );";
                ExecuteCommand(connection, commandoSQL);

                // Criar tabela de carrinhos
                commandoSQL = @"
                    CREATE TABLE IF NOT EXISTS carrinhos (
                        ID INTEGER PRIMARY KEY AUTOINCREMENT,
                        jogoid INTEGER,
                        pagamentoid INTEGER,
                        usuarioid INTEGER
                    );";
                ExecuteCommand(connection, commandoSQL);

                // Criar tabela de categorias
                commandoSQL = @"
                    CREATE TABLE IF NOT EXISTS Categorias (
                        ID INTEGER PRIMARY KEY AUTOINCREMENT,
                        Nome TEXT NOT NULL,
                        Descricao TEXT,
                        jogos TEXT
                    );";
                ExecuteCommand(connection, commandoSQL);

                // Criar tabela de compras
                commandoSQL = @"
                    CREATE TABLE IF NOT EXISTS Vendas (
                        ID INTEGER PRIMARY KEY AUTOINCREMENT,
                        carrinhoid INTEGER,   
                        data_de_compra DATETIME,
                        Usuarioid INTEGER,
                        jogoid INTEGER
                    );";
                ExecuteCommand(connection, commandoSQL);

                // Criar tabela de jogoCategorias
                commandoSQL = @"
                    CREATE TABLE IF NOT EXISTS jogoCategorias (
                        ID INTEGER PRIMARY KEY AUTOINCREMENT,
                        jogoid INTEGER,
                        categoriaid INTEGER
                    );";
                ExecuteCommand(connection, commandoSQL);

                // Criar tabela de revendedores
                commandoSQL = @"
                    CREATE TABLE IF NOT EXISTS Reevendedors (
                        ID INTEGER PRIMARY KEY AUTOINCREMENT,
                        Nome TEXT NOT NULL,
                        Endereco TEXT,
                        Telefone TEXT,
                        Email TEXT
                    );";
                ExecuteCommand(connection, commandoSQL);

                // Criar tabela de avaliações
                commandoSQL = @"
                    CREATE TABLE IF NOT EXISTS Avaliacaos (
                        ID INTEGER PRIMARY KEY AUTOINCREMENT,
                        jogoid INTEGER,
                        usuarioid INTEGER,
                        nota DECIMAL,
                        Comentario TEXT
                    );";
                ExecuteCommand(connection, commandoSQL);
            }
        }

        private static void ExecuteCommand(SQLiteConnection connection, string commandText)
        {
            using (var command = new SQLiteCommand(commandText, connection))
            {
                command.ExecuteNonQuery();
            }
        }
    }
}
