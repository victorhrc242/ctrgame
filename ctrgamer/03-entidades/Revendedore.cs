using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ctrgamer._03_entidades
{
    public class Revendedore
    {

        public int id { get; set; }
        public string nome { get; set; }
        public string senha { get; set; }
        public string empresa { get; set; }
        public int idade { get; set; }
        public string cpf { get; set; }
        public int cartão { get; set; }
    }
}
