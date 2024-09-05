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

        public int ID { get; set; }
        public DateTime DATA { get; set; }
        public string NOMEJOGO { get; set; }
        public double VALORTOTAL { get; set; }
        [Required]
        public string FORMALDEPAGAMENTO { get; set; }

    }
}
