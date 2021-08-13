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
    [RoutePrefix("api/Estado")]
    public class EstadoController : ApiController
    {
        private readonly ContextDb cx;
        private readonly EstadoMap map;
        private readonly EstadoRepository rep;
        private readonly EstadoService _serv;
        /// <summary>
        /// 
        /// </summary>
        public EstadoController() : base()
        {
            map = new EstadoMap();
            cx = new ContextDb();
            rep = new EstadoRepository(cx);
            _serv = new EstadoService(cx, rep, map);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="idPais"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("BuscaEstadosPeloIdPais/{idPais}")]
        public List<EstadoDTO> BuscaEstadosPeloIdPais(int idPais)
        {
            return _serv.GetAll().FindAll(e=>e.IdPais == idPais);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("BuscaEstadoDAOPeloId/{id}")]
        public EstadoDAO BuscaEstadoDAOPeloId(int id)
        {
            return _serv.GetDAO(id);
        }
        #region CRUD
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<EstadoDTO> GetAll()
        {
            return _serv.GetAll();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public EstadoDTO Get(int id)
        {
            return _serv.Get(id);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dao"></param>
        /// <returns></returns>
        [HttpPost]
        public EstadoDTO Post(EstadoDAO dao)
        {
            return _serv.Add(dao);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dao"></param>
        /// <returns></returns>
        [HttpPut]
        public EstadoDTO Put(EstadoDAO dao)
        {
            return _serv.Update(dao, dao.Id);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dao"></param>
        /// <returns></returns>
        [HttpDelete]
        public EstadoDTO Delete(EstadoDAO dao)
        {
            return _serv.Delete(dao, dao.Id);
        }
        #endregion
    }
}
