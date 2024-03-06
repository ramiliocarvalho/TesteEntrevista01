using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;

namespace WebAppTesteEntrevista01.Filters
{
    public class PageRestrictedAdmin : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            //Se sessão do usuário for nula ou vazia, redireciono para a controle Login (Action Index)

            string sessionUser = context.HttpContext.Session.GetString("sessionUserLoged");

            if (string.IsNullOrWhiteSpace(sessionUser))
            {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary{ { "controller", "Login"}, { "action","Index"} });
            }
            else
            {
                Models.Usuario usuario =JsonConvert.DeserializeObject<Models.Usuario>(sessionUser);
                if (usuario == null) 
                {
                    context.Result = new RedirectToRouteResult(new RouteValueDictionary { { "controller", "Login" }, { "action", "Index" } });
                }

                if (usuario.Perfil != Enums.PerfilEnums.Admin)
                {
                    context.Result = new RedirectToRouteResult(new RouteValueDictionary { { "controller", "Restricted" }, { "action", "Index" } });
                }
            }

            base.OnActionExecuting(context);
        }
    }
}
