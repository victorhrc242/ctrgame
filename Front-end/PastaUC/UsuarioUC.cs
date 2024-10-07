using ctrgamer._03_entidades;
using FrontEnd.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace FrontEnd.PastaUC
{
    public class UsuarioUC
    {
        private readonly HttpClient _client;
        public UsuarioUC(HttpClient cliente)
        {
            _client = cliente;
        }
        public usuarioS FazreLogin(Usuariologindto usodto)
        {
            HttpResponseMessage response = _client.PostAsJsonAsync("usuario/fazer-login", usodto).Result;
            usuarioS usuario = response.Content.ReadFromJsonAsync<usuarioS>().Result;
            return usuario;
        }

        public void Cadastrarusuario(usuarioS usuario)
        {
            HttpResponseMessage response = _client.PostAsJsonAsync("usuario/adicionar-usuario", usuario).Result;
        }

        public List<usuarioS> ListarUsuarios()
        {
            return _client.GetFromJsonAsync<List<usuarioS>>("usuario/Listar-usuarios").Result;
        }


    }
}
