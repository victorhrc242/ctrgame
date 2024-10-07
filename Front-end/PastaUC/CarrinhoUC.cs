using ctrgamer._03_entidades;
using ctrgamer._03_entidades.DTO.carrinho;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Front_end.PastaUC
{
    public class CarrinhoUC
    {

        private readonly HttpClient _client;
        public CarrinhoUC(HttpClient cliente)
        {
            _client = cliente;
        }
        public void CadastrarCarrinho(Carrinho carrinho)
        {
            HttpResponseMessage response = _client.PostAsJsonAsync("carrinho/adicionar-carrinho", carrinho).Result;
        }
        public List<Reeadcarrinho> ListarCarrinhoUsuarioLogado(int usuarioId)
        {
            return _client.GetFromJsonAsync<List<Reeadcarrinho>>("carrinho/Listar-carrino?usuarioid=" + usuarioId).Result;
        }
    }
}
