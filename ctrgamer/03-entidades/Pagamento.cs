﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ctrgamer._03_entidades
{
    public class Pagamento
    {
        public int Pagamentoid { get; set; }
        public int Compraid { get; set; }
        public string TipoPagamento { get; set; }
        public string status { get; set; }
    }
}
