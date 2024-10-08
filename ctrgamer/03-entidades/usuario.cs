﻿using System;
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
        //[Required]
        public string NOME { get; set; }
        //[Required(ErrorMessage ="falta de cpf")]
        //[MinLength(12)]
        public string Username {  get; set; }
        public double CPF { get; set; }
        //[Required]
        //[Range(16,100,ErrorMessage ="voce não tem idade suficiente")]
        public int IDADE { get; set; }
        //[Required(ErrorMessage ="error email obrigatorio")]
        //[EmailAddress(ErrorMessage ="email invalido")]
        public string EMAIL { get; set; }
        //[Required]
        //[MinLength(7,ErrorMessage ="erro minimo 7 caracter ")]
        public  string SENHA { get; set; }
    }
}
