﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ctrgamer._03_entidades.DTO.carrinho;

public class Reeadcarrinho
{
    public int ID { get; set; }
    public usuarioS usuario { get; set; }
    public Jogo jogo { get; set; }
    public string Status { get; set; }  
}
