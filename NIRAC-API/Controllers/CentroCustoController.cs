using System.Collections.Generic;
using System.Web.Http;
using NIRAC_BUSINESS.Context;
using NIRAC_BUSINESS.Models.DAO;
using NIRAC_BUSINESS.Models.DTO;
using NIRAC_BUSINESS.Models.Map;
using NIRAC_BUSINESS.Repository;
using NIRAC_BUSINESS.Services;

namespace NIRAC_API.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [RoutePrefix("api/CentroCusto")]
    public class CentroCustoController : ApiController
    {
        private readonly ContextDb cx;
        private readonly CentroCustoMap map;
        private readonly CentroCustoRepository rep;
        private readonly CentroCustoService _serv;
        /// <summary>
        /// 
        /// </summary>
        public CentroCustoController() : base()
        {
            map = new CentroCustoMap();
            cx = new ContextDb();
            rep = new CentroCustoRepository(cx);
            _serv = new CentroCustoService(cx, rep, map);
        }
        #region CRUD
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<CentroCustoDTO> GetAll()
        {
            return _serv.GetAll();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public CentroCustoDTO Get(int id)
        {
            return _serv.Get(id);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dao"></param>
        /// <returns></returns>
        [HttpPost]
        public CentroCustoDTO Post(CentroCustoDAO dao)
        {
            return _serv.Add(dao);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dao"></param>
        /// <returns></returns>
        [HttpPut]
        public CentroCustoDTO Put(CentroCustoDAO dao)
        {
            return _serv.Update(dao, dao.Id);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dao"></param>
        /// <returns></returns>
        [HttpDelete]
        public CentroCustoDTO Delete(CentroCustoDAO dao)
        {
            return _serv.Delete(dao, dao.Id);
        }
        #endregion
    }
}
