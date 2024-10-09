using ctrgamer._03_entidades;
using ctrgamer._03_entidades.DTO.Compra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Front_end.PastaUC
{
    public class CompraUC
    {
        private readonly HttpClient _client;
        public CompraUC(HttpClient cliente)
        {
            _client = cliente;
        }
        public Compra CadastrarVenda(Compra venda)
        {
            HttpResponseMessage response = _client.PostAsJsonAsync("compracontroleer/adicionar-usuario", venda).Result;

            Compra vendaCadastrada = response.Content.ReadFromJsonAsync<Compra>().Result;
            return vendaCadastrada;
        }


        public ReadCompraDTO BuscarVendaPorId(int id)
        {
            return _client.GetFromJsonAsync<ReadCompraDTO>("Listar-compra?usuarioid=" + id).Result;
        }


    }
}
