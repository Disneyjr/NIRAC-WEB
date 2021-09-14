using System.Web.Http;
using System.Web.Http.Cors;

namespace NIRAC_API
{
    /// <summary>
    /// Arquivo de Configuração da API
    /// </summary>
    public static class WebApiConfig
    {
        /// <summary>
        /// Registro da API
        /// </summary>
        /// <param name="config"></param>
        public static void Register(HttpConfiguration config)
        {
            // Serviços e configuração da API da Web

            // Rotas da API da Web
            config.MapHttpAttributeRoutes();
            var cors = new EnableCorsAttribute("https://localhost:44308,https://www.nirac.com.br", "*", "*");
            config.EnableCors(cors);

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
