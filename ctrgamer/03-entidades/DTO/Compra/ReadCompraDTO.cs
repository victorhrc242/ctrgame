using ctrgamer._03_entidades.DTO.carrinho;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ctrgamer._03_entidades.DTO.Compra
{
    public class ReadCompraDTO
    {

        public int Id { get; set; }
        public Carrinho Carrinho { get; set; }
        public usuarioS usuario { get; set; }
        public DateTime DataCompra { get; set; }
        public double ValorFinal { get; set; }
        public string MetodoPagamento { get; set; }


    }
}
