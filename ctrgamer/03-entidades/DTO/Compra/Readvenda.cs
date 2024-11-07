using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ctrgamer._03_entidades.DTO.Compra
{
    public class Readvenda
    {
        public int ID { get; set; }
        public usuarioS usuario { get; set;}
        public Carrinho carrinho { get; set; }

    }
}
