using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ctrgamer._03_entidades
{
    public class Carrinho
    {

        public int id { get; set; }
        public DateTime Data { get; set; }
        public string nomejogo { get; set; }
        public double ValorTotal { get; set; }
        [Required]
        public string Formapagamento { get; set; }

    }
}
