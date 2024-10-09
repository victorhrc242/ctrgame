using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ctrgamer._03_entidades;

public class Compra
{
    public int Id { get; set; }
    public int carrinhoid { get; set; }
    public int usuarioid { get; set; }
    public string tipodepagamento { get; set; }
    public DateTime Datacompra { get; set; }
    public double ValorFinal { get; set; }
 
    public string GetMetodoPagamentoById(int opcaoSelecionada)
    {
        switch (opcaoSelecionada)
        {
            case 1:
                return "PIX";
            case 2:
                return "Débito";
            case 3:
                return "Crédito";
            default:
                return null;
        }
    }
}
