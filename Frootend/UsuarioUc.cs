using ctrgamer._03_entidades;
using FrontEnd.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Frootend
{
    public class UsuarioUc
    {
        private readonly HttpClient _client;
        public UsuarioUc(HttpClient client)
        {
            _client = client;
        }

        public List<usuarioS> ListarUsuarios()
        {
            return _client.GetFromJsonAsync<List<usuarioS>>("Usuario/listar-usuario").Result;
        }
        public void CadastrarUsuario(usuarioS usuario)
        {
            HttpResponseMessage response = _client.PostAsJsonAsync("usuario/adicionar-usuario", usuario).Result;
        }
        public usuarioS FazerLogin(Usuariologindto usuLogin)
        {
            HttpResponseMessage response = _client.PostAsJsonAsync("usuario/fazer-login", usuLogin).Result;
            usuarioS usuario = response.Content.ReadFromJsonAsync<usuarioS>().Result;
            return usuario;
        }
    }
}
