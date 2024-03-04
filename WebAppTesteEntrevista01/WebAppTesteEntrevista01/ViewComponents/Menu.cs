using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace WebAppTesteEntrevista01.ViewComponents
{
    public class Menu : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            string sessionUser = HttpContext.Session.GetString("sessionUserLoged");

            if (string.IsNullOrWhiteSpace(sessionUser)) return null;

            Models.Usuario usuario = JsonConvert.DeserializeObject<Models.Usuario>(sessionUser);

            return View(usuario);
        }
    }
}
