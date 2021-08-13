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
    [RoutePrefix("api/CentroCustoUsuario")]
    public class CentroCustoUsuarioController : ApiController
    {
        private readonly ContextDb cx;
        private readonly CentroCustoUsuarioMap map;
        private readonly CentroCustoUsuarioRepository rep;
        private readonly CentroCustoUsuarioService _serv;
        /// <summary>
        /// 
        /// </summary>
        public CentroCustoUsuarioController() : base()
        {
            map = new CentroCustoUsuarioMap();
            cx = new ContextDb();
            rep = new CentroCustoUsuarioRepository(cx);
            _serv = new CentroCustoUsuarioService(cx, rep, map);
        }
        #region CRUD
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<CentroCustoUsuarioDTO> GetAll()
        {
            return _serv.GetAll();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public CentroCustoUsuarioDTO Get(int id)
        {
            return _serv.Get(id);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dao"></param>
        /// <returns></returns>
        [HttpPost]
        public CentroCustoUsuarioDTO Post(CentroCustoUsuarioDAO dao)
        {
            return _serv.Add(dao);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dao"></param>
        /// <returns></returns>
        [HttpPut]
        public CentroCustoUsuarioDTO Put(CentroCustoUsuarioDAO dao)
        {
            return _serv.Update(dao, dao.Id);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dao"></param>
        /// <returns></returns>
        [HttpDelete]
        public CentroCustoUsuarioDTO Delete(CentroCustoUsuarioDAO dao)
        {
            return _serv.Delete(dao, dao.Id);
        }
        #endregion
    }
}
