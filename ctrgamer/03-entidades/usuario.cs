using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ctrgamer._03_entidades
{
    public class usuario
    {
        public int id { get; set; }


        [Required]
        public string Nome { get; set; }






        [Required(ErrorMessage ="falta de cpf")]
        [MinLength(12)]
        public double cpf { get; set; }
        [Required]
        [Range(16,100,ErrorMessage ="voce não tem idade suficiente")]
        public int idade { get; set; }




        [Required(ErrorMessage ="error email obrigatorio")]
        [EmailAddress(ErrorMessage ="email invalido")]
        public string Email { get; set; }




        [Required]
        [MinLength(7,ErrorMessage ="erro minimo 7 caracter ")]
        public  string Senha { get; set; }
    }
}
