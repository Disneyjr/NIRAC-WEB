﻿using NIRAC_BUSINESS.Models.DAO;
using NIRAC_BUSINESS.Models.DTO;
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
            return View(emprestimoWebService.GetAll());
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
        private List<ParcelaDTO> GetParcelas(FormCollection form)
        {
            int quantidadeParcela = Convert.ToInt16(form["QuantidadeParcela"].ToString());
            decimal juros = Convert.ToInt16(form["PorcentagemJuros"].ToString());
            decimal jurosReal = juros / 100;
            int valorTotalParcela = Convert.ToInt16(form["TotalEmprestimo"].ToString());
            decimal valorParcela = valorTotalParcela / quantidadeParcela;
            decimal valorParcelaAntigo = 0;
            List<ParcelaDTO> parcelas = new List<ParcelaDTO>();
            for (int i = 0; i < quantidadeParcela; i++)
            {
                ParcelaDTO parcela = new ParcelaDTO();
                parcela.DataCriacao = DateTime.Now;
                parcela.DataAtualizacao = DateTime.Now;
                parcela.IdEmprestimo = 0;
                if (i == 0)
                {
                    parcela.Valor = valorParcela;
                    valorParcelaAntigo = valorParcela;
                }
                else
                {
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
        #endregion
    }
}