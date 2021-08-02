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
            EmprestimoVM emprestimoVM = new EmprestimoVM();
            emprestimoVM.listaemprestimos = emprestimoWebService.GetAll();
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
            emprestimoDAO.PorcentagemJuros = emprestimoDAO.PorcentagemJuros;
            emprestimoDAO.QuantidadeParcela = emprestimoDAO.QuantidadeParcela;
            emprestimoDAO.TotalEmprestimo = emprestimoDAO.TotalEmprestimo;
            emprestimoDAO.TotalHaver = emprestimoDAO.TotalEmprestimo;
            emprestimoDAO.IdCliente = Convert.ToInt32(form["cliente"].ToString());
            emprestimoDAO.IdUsuario = Convert.ToInt32(Session["IdUsuario"]);
            emprestimoDAO.parcelas = GetParcelas(form);
            if (emprestimoWebService.Add(emprestimoDAO))
            {
                return RedirectToAction("Index", "Emprestimo");
            }
            else
            {
                return RedirectToAction("Cadastrar", "Emprestimo");
            }
        }
        [HttpPost]
        public ActionResult EmprestimoDeletar()
        {
            return null;
        }
        #region PRIVATE METHODS
        private List<ParcelaDAO> GetParcelas(FormCollection form)
        {
            int quantidadeParcela = Convert.ToInt16(form["QuantidadeParcela"].ToString());
            int diaCobranca = Convert.ToInt16(form["DiaCobranca"].ToString());
            decimal juros = Convert.ToInt16(form["PorcentagemJuros"].ToString());
            decimal jurosReal = juros / 100;
            int valorTotalParcela = Convert.ToInt16(form["TotalEmprestimo"].ToString());
            decimal valorParcela = valorTotalParcela / quantidadeParcela;
            decimal valorParcelaAntigo = 0;
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
                    parcela.Valor = valorParcela;
                    valorParcelaAntigo = valorParcela;
                }
                else
                {
                    parcela.DataPagamento = GetDataPagamento(DateTime.Now, diaCobranca, i);
                    valorParcelaAntigo = CalculaValoresParcela(jurosReal, valorParcelaAntigo);
                    parcela.Valor = valorParcelaAntigo;
                }
                parcela.ValorPago = 0;
                parcela.ValorRestanteParcela = 0;
                parcelas.Add(parcela);
            }
            return parcelas;
        }
        private decimal CalculaValoresParcela(decimal juros, decimal valor)
        {
            return (valor * juros) + valor;
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