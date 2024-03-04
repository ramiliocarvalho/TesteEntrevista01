using Newtonsoft.Json;
using WebAppTesteEntrevista01.Models;

namespace WebAppTesteEntrevista01.Helper
{
    public class Sessao : ISessao
    {
        private readonly IHttpContextAccessor _httpContext;

        public Sessao(IHttpContextAccessor httpContext)
        {
            _httpContext = httpContext;
        }
        public void CreateSessionUser(Usuario usuario)
        {
            string valor = JsonConvert.SerializeObject(usuario);
            _httpContext.HttpContext.Session.SetString("sessionUserLoged", valor);
        }

        public Usuario GetSessionUser()
        {
            string sessaoUsuario = _httpContext.HttpContext.Session.GetString("sessionUserLoged");

            if (string.IsNullOrWhiteSpace(sessaoUsuario)) return null;

            return JsonConvert.DeserializeObject<Usuario>(sessaoUsuario);
        }

        public void RemoveSessionUser()
        {
            _httpContext.HttpContext.Session.Remove("sessionUserLoged");
        }
    }
}
