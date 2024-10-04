using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ctrgamer._03_entidades
{
    public class Jogo
    {

        public int ID { get; set; }
        public string NOME { get; set; }
        public string DESCRICAO { get; set; }
        public double preco { get; set; }
        public DateTime DATA { get; set; }
        public override string ToString()
        {
            return $"Id: {ID} - Nome: {NOME} - Descrição: {DESCRICAO} -Data: {DATA}-Preço {preco}";
        }

    }
}
