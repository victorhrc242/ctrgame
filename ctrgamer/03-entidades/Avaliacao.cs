using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ctrgamer._03_entidades
{
    public class Avaliacao
    {
        public int Avaliacaoid { get; set; }
        public int jogoid { get; set; }
        public int usuarioid { get; set; }
        public int nota { get; set; }
        public string Comentario { get; set; }
    }
}
