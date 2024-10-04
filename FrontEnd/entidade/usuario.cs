using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ctrgamer._03_entidades
{
    public class usuarioS
    {
        public int ID { get; set; }
        public string NOME { get; set; }
        public string Username {  get; set; }
        public double CPF { get; set; }
        public int IDADE { get; set; }
        public string EMAIL { get; set; }
        public  string SENHA { get; set; }

        public override string ToString()
        {
            return $"Id: {ID} - Nome: {NOME} - Username: {Username} - E-mail: {EMAIL}";
        }
    }
}
