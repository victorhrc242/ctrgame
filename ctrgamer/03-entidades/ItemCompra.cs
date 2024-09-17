using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ctrgamer._03_entidades
{
    public class ItemCompra
    {
        public int id { get; set; }
        public int Compraid { get; set; }
        public int jogoid { get; set; }
        public int quantidade { get; set; }
        public decimal precounutario { get; set; }
        public decimal totalitem { get; set; }
    }
}
