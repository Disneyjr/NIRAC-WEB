using System.Web.Mvc;
using System.Web.Mvc.Filters;

namespace NIRAC_WEB.Controllers
{
    public class Autentica : ActionFilterAttribute
    {
        public string Modulo { get; set; }
        public string Tipo { get; set; }
        public string Funcionalidade { get; set; }
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            object Id = filterContext.HttpContext.Request.Cookies.Get("Id").Value;
            object TipoUsuario = filterContext.HttpContext.Request.Cookies.Get("Tipo").Value;
            if (Id == null || TipoUsuario == null)
            {
                filterContext.Result = new RedirectToRouteResult(
                    new System.Web.Routing.RouteValueDictionary(
                            new { controller = "Login", action = "Index" }
                        )
                );
            }
            else
            {
                if (!Tipo.Equals(TipoUsuario))
                {
                    filterContext.Result = new RedirectToRouteResult(
                        new System.Web.Routing.RouteValueDictionary(
                                new { controller = "Login", action = "Index" }
                            )
                        );
                }
            }
        }
    }
}