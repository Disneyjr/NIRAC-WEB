using NIRAC_BUSINESS.Context;
using NIRAC_BUSINESS.Models.DAO;
using NIRAC_BUSINESS.Models.DTO;
using NIRAC_BUSINESS.Models.Map;
using NIRAC_BUSINESS.Repository;
using NIRAC_BUSINESS.Services;
using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;

namespace NIRAC_API.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [RoutePrefix("api/Emprestimo")]
    public class EmprestimoController : ApiController
    {
        private readonly ContextDb cx;
        private readonly EmprestimoMap map;
        private readonly EmprestimoRepository rep;
        private readonly EmprestimoService _serv;
        /// <summary>
        /// 
        /// </summary>
        public EmprestimoController()
        {
            map = new EmprestimoMap();
            cx = new ContextDb();
            rep = new EmprestimoRepository(cx);
            _serv = new EmprestimoService(cx, rep, map);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="IdEmpresa"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("BuscaEmprestimosPeloIdEmpresa/{IdEmpresa}")]
        public List<EmprestimoDTO> BuscaEmprestimosPeloIdEmpresa(int IdEmpresa)
        {
            return _serv.GetAll().FindAll(u => u.IdEmpresa == IdEmpresa);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("BuscaEmprestimosPeloIdUsuario/{id}")]
        public List<EmprestimoDTO> BuscaEmprestimosPeloIdUsuario(int id)
        {
            return _serv.GetAll().FindAll(u => u.IdUsuario == id);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="valorFinanciado"></param>
        /// <param name="numeroParcelas"></param>
        /// <param name="juros"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("CalculaParcela/{valorFinanciado}/{numeroParcelas}/{juros}")]
        public double CalculaParcela(double valorFinanciado, int numeroParcelas,double juros)
        {
            double jurosReal = juros / 100;
            double calculoJuros = (valorFinanciado * Math.Pow((1 + jurosReal), numeroParcelas) * jurosReal) / (Math.Pow((1 + jurosReal), numeroParcelas) - 1);
            return Math.Round(calculoJuros, 2); 
        }
          
        /// <summary>
        /// 
        /// </summary>
        /// <param name="valorFinanciado"></param>
        /// <param name="numeroParcelas"></param>
        /// <param name="juros"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("TotalFinanciamento/{valorFinanciado}/{numeroParcelas}/{juros}")]
        public double TotalFinanciamento(double valorFinanciado, int numeroParcelas, double juros)
        {
            double jurosReal = juros / 100;
            double calculoJuros = (valorFinanciado * Math.Pow((1 + jurosReal), numeroParcelas) * jurosReal) / (Math.Pow((1 + jurosReal), numeroParcelas) - 1);
            return Math.Round((calculoJuros * numeroParcelas), 2);
        }
        #region CRUD
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<EmprestimoDTO> GetAll()
        {
            return _serv.GetAll();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public EmprestimoDTO Get(int id)
        {
            return _serv.Get(id);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dao"></param>
        /// <returns></returns>
        [HttpPost]
        public EmprestimoDTO Post(EmprestimoDAO dao)
        {
            return _serv.Add(dao);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dao"></param>
        /// <returns></returns>
        [HttpPut]
        public EmprestimoDTO Put(EmprestimoDAO dao)
        {
            return _serv.Update(dao, dao.Id);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dao"></param>
        /// <returns></returns>
        [HttpDelete]
        public EmprestimoDTO Delete(EmprestimoDAO dao)
        {
            return _serv.Delete(dao, dao.Id);
        }
        #endregion
    }
}
