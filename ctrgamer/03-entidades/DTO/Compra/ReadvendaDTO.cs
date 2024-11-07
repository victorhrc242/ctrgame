using ctrgamer._03_entidades.DTO.carrinho;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ctrgamer._03_entidades.DTO.Compra
{
    public class ReadvendaDTO
    {
        public int ID { get; set; }
        public usuarioS Usuario  { get; set;}
        public Carrinho Carrinho { get; set; }
     

    }
}
