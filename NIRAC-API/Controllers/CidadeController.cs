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
    [RoutePrefix("api/Cidade")]
    public class CidadeController : ApiController
    {
        private readonly ContextDb cx;
        private readonly CidadeMap map;
        private readonly CidadeRepository rep;
        private readonly CidadeService _serv;
        /// <summary>
        /// 
        /// </summary>
        public CidadeController() : base()
        {
            map = new CidadeMap();
            cx = new ContextDb();
            rep = new CidadeRepository(cx);
            _serv = new CidadeService(cx, rep, map);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="idEstado"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("BuscaCidadesPeloIdEstado/{idEstado}")]
        public List<CidadeDTO> BuscaCidadesPeloIdEstado(int idEstado)
        {
            return _serv.GetAll().FindAll(e => e.IdEstado == idEstado);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("BuscaCidadeDAOPeloId/{id}")]
        public CidadeDAO BuscaCidadeDAOPeloId(int id)
        {
            return _serv.GetDAO(id);
        }
        #region CRUD
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<CidadeDTO> GetAll()
        {
            return _serv.GetAll();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public CidadeDTO Get(int id)
        {
            return _serv.Get(id);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dao"></param>
        /// <returns></returns>
        [HttpPost]
        public CidadeDTO Post(CidadeDAO dao)
        {
            return _serv.Add(dao);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dao"></param>
        /// <returns></returns>
        [HttpPut]
        public CidadeDTO Put(CidadeDAO dao)
        {
            return _serv.Update(dao, dao.Id);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dao"></param>
        /// <returns></returns>
        [HttpDelete]
        public CidadeDTO Delete(CidadeDAO dao)
        {
            return _serv.Delete(dao, dao.Id);
        }
        #endregion
    }
}
