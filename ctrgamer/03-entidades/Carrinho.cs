using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace ctrgamer._03_entidades
{
    public class Carrinho
    {

        public int ID { get; set; }
        public int usuarioid { get; set; }
        public int JogoId { get; set; }

    }
}
