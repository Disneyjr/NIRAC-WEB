using System.Web.Mvc;

namespace NIRAC_WEB.Controllers
{
    public class Autentica : ActionFilterAttribute
    {
        public string Modulo { get; set; }
        public string TipoAcesso { get; set; }
        public string Funcionalidade { get; set; }
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if(filterContext.HttpContext.Request.Cookies.Count > 0)
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
                    if (!TipoAcesso.Equals(TipoUsuario))
                    {
                        filterContext.Result = new RedirectToRouteResult(
                            new System.Web.Routing.RouteValueDictionary(
                                    new { controller = "Login", action = "Index" }
                                )
                            );
                    }
                }
            }
            else
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