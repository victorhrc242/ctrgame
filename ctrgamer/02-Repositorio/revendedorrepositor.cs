﻿using ctrgamer._02_Repositorio.Interfaces;
using ctrgamer._03_entidades;
using Dapper.Contrib.Extensions;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ctrgamer._02_Repositorio
{
    public class revendedorrepositor:IRevendedorRepositor
    {
        private readonly string ConnectionString;
        public revendedorrepositor(IConfiguration configuration)
        {

            ConnectionString = configuration.GetConnectionString("DefaultConnection");

        }
        public void Adicionar(Reevendedor r)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            connection.Insert<Reevendedor>(r);

        }
        public List<Reevendedor> listar()
        {
            {
                using var connection = new SQLiteConnection(ConnectionString);
                {
                    List<Reevendedor> u = connection.GetAll<Reevendedor>().ToList();
                    return u;
                }
            }
        }
        public Reevendedor Buscarporid(int id)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            return connection.Get<Reevendedor>(id);
        }
        public void Remover(int id)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            Reevendedor novoproduto = Buscarporid(id);
            connection.Delete<Reevendedor>(novoproduto);
        }
        public void editar(Reevendedor r)
        {
            using var connection = new SQLiteConnection(ConnectionString);

            connection.Update<Reevendedor>(r);
        }
    }
}
