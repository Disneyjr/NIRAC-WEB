using NIRAC_BUSINESS.Models.DTO;
using NIRAC_WEB.WebServices;
using System;
using System.Web;
using System.Web.Mvc;

namespace NIRAC_WEB.Controllers
{
    [Autentica(Modulo = "Perfil", TipoAcesso = "NIRAC-ALL")]
    public class PerfilController : Controller
    {
        private readonly UsuarioWebService usuarioService;

        public PerfilController()
        {
            usuarioService = new UsuarioWebService();
        }

        public ActionResult PerfilUsuario()
        {
            int idUsuario = Convert.ToInt32(Request.Cookies.Get("Id").Value);
            UsuarioDTO usuarioDTO = usuarioService.GetUsuario(idUsuario);

            return View(usuarioDTO);
        }
    }
}