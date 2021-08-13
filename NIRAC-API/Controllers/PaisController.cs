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
    [RoutePrefix("api/Pais")]
    public class PaisController : ApiController
    {
        private readonly ContextDb cx;
        private readonly PaisMap map;
        private readonly PaisRepository rep;
        private readonly PaisService _serv;
        /// <summary>
        /// 
        /// </summary>
        public PaisController():base()
        {
            map = new PaisMap();
            cx = new ContextDb();
            rep = new PaisRepository(cx);
            _serv = new PaisService(cx, rep, map);
        }
        #region CRUD
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<PaisDTO> GetAll()
        {
            return _serv.GetAll();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public PaisDTO Get(int id)
        {
            return _serv.Get(id);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetDAO/{id}")]
        public PaisDAO GetDAO(int id)
        {
            return _serv.GetDAO(id);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dao"></param>
        /// <returns></returns>
        [HttpPost]
        public PaisDTO Post(PaisDAO dao)
        {
            return _serv.Add(dao);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dao"></param>
        /// <returns></returns>
        [HttpPut]
        public PaisDTO Put(PaisDAO dao)
        {
            return _serv.Update(dao, dao.Id);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dao"></param>
        /// <returns></returns>
        [HttpDelete]
        public PaisDTO Delete(PaisDAO dao)
        {
            return _serv.Delete(dao, dao.Id);
        }
        #endregion
    }
}
