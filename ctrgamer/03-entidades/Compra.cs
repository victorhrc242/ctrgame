using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ctrgamer._03_entidades;

public class Compra
{
    public int Id { get; set; }
    public int Compraid { get; set; }
    public int usuarioid { get; set; }
    public DateTime Datacompra { get; set; }
    public decimal total { get; set; }
    public string itens { get; set; }
}
