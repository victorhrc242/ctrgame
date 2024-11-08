using ctrgamer._03_entidades;
using FrontEnd.DTOS;
using System.Net.Http.Json;

namespace Front_End_ADM.UsuarioU
{
    public class UsuarioUC
    {
        private readonly HttpClient _client;
        public UsuarioUC(HttpClient cliente)
        {
            _client = cliente;
        }
        public usua FazreLogin(Usuariologindto usodto)
        {
            HttpResponseMessage response = _client.PostAsJsonAsync("usuario/fazer-login", usodto).Result;
            usuarioS usuario = response.Content.ReadFromJsonAsync<usuarioS>().Result;
            return usuario;
        }

        public void Cadastrarusuario(usuarioS usuario)
        {
            HttpResponseMessage response = _client.PostAsJsonAsync("adicionar-Revenddedor", usuario).Result;
        }

        public List<usuarioS> ListarUsuarios()
        {
            return _client.GetFromJsonAsync<List<usuarioS>>("usuario/Listar-usuarios").Result;
        }


    }
}
