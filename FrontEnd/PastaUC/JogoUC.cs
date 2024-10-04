using ctrgamer._03_entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace FrontEnd.PastaUC
{
    public class JogoUC
    {
        private readonly HttpClient _cliente;
        public JogoUC(HttpClient cliente)
        {
            cliente = _cliente;
        }
        public List<Jogo> ListarProduto()
        {


            return _cliente.GetFromJsonAsync<List<Jogo>>("jogos/Listar-jogos").Result;
            
        }
    }
}
