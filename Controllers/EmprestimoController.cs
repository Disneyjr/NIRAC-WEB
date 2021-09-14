using NIRAC_BUSINESS.Models.DAO;
using NIRAC_BUSINESS.Models.DTO;
using NIRAC_WEB.ViewModel;
using NIRAC_WEB.WebServices;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace NIRAC_WEB.Controllers
{
    [Autentica(Modulo = "Emprestimo", TipoAcesso = "NIRAC-ALL")]
    public class EmprestimoController : Controller
    {
        private EmprestimoWebService emprestimoWebService;

        public EmprestimoController()
        {
            this.emprestimoWebService = new EmprestimoWebService();
        }

        public ActionResult Index()
        {
            int idUsuarioAdm = Convert.ToInt32(Session["IdUsuario"]);
            EmprestimoVM emprestimoVM = new EmprestimoVM();
            emprestimoVM.listaemprestimos = emprestimoWebService.GetAll(idUsuarioAdm);
            return View(emprestimoVM);
        }
        public ActionResult Cadastrar()
        {
            int idUsuarioAdm = Convert.ToInt32(Session["IdUsuario"]);
            ViewBag.ListaClientes = emprestimoWebService.GetClientes(idUsuarioAdm);
            return View();
        }
        public ActionResult Editar()
        {
            return View();
        }
        public ActionResult EmprestimoDetalhe(int id)
        {
            int idUsuarioAdm = Convert.ToInt32(Session["IdUsuario"]);
            ViewBag.ListaClientes = emprestimoWebService.GetClientes(idUsuarioAdm);
            return View();
        }
        [HttpPost]
        public ActionResult EmprestimoEditar()
        {
            return null;
        }
        [HttpPost]
        public ActionResult EmprestimoCadastrar(EmprestimoDAO emprestimoDAO, FormCollection form)
        {
            
            emprestimoDAO.DataAtualizacao = DateTime.Now;
            emprestimoDAO.DataCriacao = DateTime.Now;
            emprestimoDAO.DataUltimoPagamento = DateTime.Now;
            emprestimoDAO.IdCliente = Convert.ToInt32(form["cliente"].ToString());
            emprestimoDAO.IdUsuario = Convert.ToInt32(Session["IdUsuario"]);
            emprestimoDAO.parcelas = GetParcelas(emprestimoDAO, form);
            emprestimoDAO.TotalEmprestimo = Convert.ToInt16(form["MontantePego"].ToString());
            emprestimoDAO.PorcentagemJuros = Convert.ToInt16(form["Juros"].ToString());
            emprestimoDAO.DiaPagamento = Convert.ToInt16(form["DiaCobranca"].ToString());
            emprestimoDAO.QuantidadeParcela = Convert.ToInt16(emprestimoDAO.QuantidadeParcela);
            if (emprestimoWebService.Add(emprestimoDAO))
            {
                return RedirectToAction("Index", "Emprestimo");
            }
            else
            {
                return RedirectToAction("Cadastrar", "Emprestimo");
            }
        }
        
        public ActionResult EmprestimoDeletar(int id)
        {
            List<ParcelaDAO> parcelas = emprestimoWebService.GetParcelas(id);
            EmprestimoDAO emprestimoDAO = emprestimoWebService.GetEmprestimo(id);
            emprestimoWebService.Delete(id, emprestimoDAO, parcelas);
            return RedirectToAction("Index", "Emprestimo");
        }
        #region PRIVATE METHODS
        private List<ParcelaDAO> GetParcelas(EmprestimoDAO emprestimoDAO, FormCollection form)
        {
            int quantidadeParcela = Convert.ToInt16(emprestimoDAO.QuantidadeParcela);
            int diaCobranca = Convert.ToInt16(form["DiaCobranca"].ToString());
            decimal montantePego = Convert.ToInt16(form["MontantePego"].ToString());
            decimal juros = Convert.ToInt16(form["Juros"].ToString());
            decimal jurosReal = juros / 100;
            decimal valorParcela = Convert.ToDecimal(emprestimoWebService.GetValorParcela(montantePego, quantidadeParcela, juros));
            List<ParcelaDAO> parcelas = new List<ParcelaDAO>();
            for (int i = 0; i < quantidadeParcela; i++)
            {
                ParcelaDAO parcela = new ParcelaDAO();
                parcela.DataCriacao = DateTime.Now;
                parcela.DataAtualizacao = DateTime.Now;
                parcela.IdEmprestimo = 0;
                if (i == 0)
                {
                    parcela.DataPagamento = DateTime.Now;
                }
                else
                {
                    parcela.DataPagamento = GetDataPagamento(DateTime.Now, diaCobranca, i);
                }
                parcela.Valor = valorParcela;
                parcela.ValorPago = 0;
                parcela.ValorRestanteParcela = 0;
                parcelas.Add(parcela);
            }
            return parcelas;
        }
        private DateTime GetDataPagamento(DateTime dataAtual, int diaCobranca, int indice)
        {
            DateTime DataPagamento = new DateTime();
            DataPagamento = dataAtual;
            var mes = dataAtual.Month + indice;
            var mesSub = mes - dataAtual.Month;
            var Data = DataPagamento.AddMonths(mesSub);
            return Data;
        }
        #endregion
    }
}