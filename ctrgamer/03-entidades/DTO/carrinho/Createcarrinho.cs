using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ctrgamer._03_entidades.DTO.carrinho;

public class Createcarrinho
{

    public int usuarioid { get; set; }
    public int JogoId { get; set; }
    [Required]
    public string FORMALDEPAGAMENTO { get; set; }

}
