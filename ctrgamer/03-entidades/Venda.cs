using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ctrgamer._03_entidades
{
    public class Venda
    {
        public int id { get; set; }
        public int Usuarioid { get; set; }
        public int carrinhoid { get; set; }
        public DateTime data_de_compra { get; set; }
    }
}
