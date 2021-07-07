using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NIRAC_WEB.Controllers
{
    public class EmprestimoController : Controller
    {
        // GET: Emprestimo
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Cadastrar()
        {
            return View();
        }
        public ActionResult Editar()
        {
            return View();
        }
    }
}