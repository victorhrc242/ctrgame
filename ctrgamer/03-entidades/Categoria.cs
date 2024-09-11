using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ctrgamer._03_entidades
{
    public class Categoria
    {
        public int Categoriaid { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public List<Jogo> jogos { get; set; }
    }
}
