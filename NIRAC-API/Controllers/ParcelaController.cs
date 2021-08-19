using NIRAC_BUSINESS.Context;
using NIRAC_BUSINESS.Models.DAO;
using NIRAC_BUSINESS.Models.DTO;
using NIRAC_BUSINESS.Models.Map;
using NIRAC_BUSINESS.Repository;
using NIRAC_BUSINESS.Services;
using System.Collections.Generic;
using System.Web.Http;

namespace NIRAC_API.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [RoutePrefix("api/Parcela")]
    public class ParcelaController : ApiController
    {
        private readonly ContextDb cx;
        private readonly ParcelaMap map;
        private readonly ParcelaRepository rep;
        private readonly ParcelaService _serv;
        /// <summary>
        /// 
        /// </summary>
        public ParcelaController()
        {
            map = new ParcelaMap();
            cx = new ContextDb();
            rep = new ParcelaRepository(cx);
            _serv = new ParcelaService(cx, rep, map);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("BuscaParcelasPeloIdEmprestimo/{id}")]
        public List<ParcelaDTO> BuscaParcelasPeloIdEmprestimo(int id)
        {
            return _serv.GetAll().FindAll(u => u.IdEmprestimo == id);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dao"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("ParcelaList")]
        public void PostList(List<ParcelaDAO> daos)
        {
            daos.ForEach(a => _serv.Add(a));
        }
        #region CRUD
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<ParcelaDTO> GetAll()
        {
            return _serv.GetAll();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ParcelaDTO Get(int id)
        {
            return _serv.Get(id);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dao"></param>
        /// <returns></returns>
        [HttpPost]
        public ParcelaDTO Post(ParcelaDAO dao)
        {
            return _serv.Add(dao);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dao"></param>
        /// <returns></returns>
        [HttpPut]
        public ParcelaDTO Put(ParcelaDAO dao)
        {
            return _serv.Update(dao, dao.Id);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dao"></param>
        /// <returns></returns>
        [HttpDelete]
        public ParcelaDTO Delete(ParcelaDAO dao)
        {
            return _serv.Delete(dao, dao.Id);
        }
        #endregion
    }
}
