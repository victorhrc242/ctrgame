﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ctrgamer._03_entidades
{
    public class Jogos
    {

        public int id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public double preco { get; set; }
        public DateTime DataDeLancamento { get; set; }
    }
}
