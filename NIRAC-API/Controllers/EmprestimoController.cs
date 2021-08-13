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
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("BuscaEmprestimosPeloIdUsuario/{id}")]
        public List<EmprestimoDTO> BuscaEmprestimosPeloIdUsuario(int id)
        {
            return _serv.GetAll().FindAll(u => u.IdUsuario == id);
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
