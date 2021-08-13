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
    [RoutePrefix("api/Empresa")]
    public class EmpresaController : ApiController
    {
        private readonly ContextDb cx;
        private readonly EmpresaMap map;
        private readonly EmpresaRepository rep;
        private readonly EmpresaService _serv;
        /// <summary>
        /// 
        /// </summary>
        public EmpresaController() : base()
        {
            map = new EmpresaMap();
            cx = new ContextDb();
            rep = new EmpresaRepository(cx);
            _serv = new EmpresaService(cx, rep, map);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("BuscaEmpresaDAOPeloId/{id}")]
        public EmpresaDAO BuscaEmpresaDAOPeloId(int id)
        {
            return _serv.GetDAO(id);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="idUsuario"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("BuscaEmpresaCadastradaPeloIdUsuarioAdm/{idUsuario}")]
        public EmpresaDTO BuscaEmpresaCadastradaPeloIdUsuarioAdm(int idUsuario)
        {
            return _serv.GetAll().Find(e=>e.IdUsuarioAdm == idUsuario);
        }
        #region CRUD
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<EmpresaDTO> GetAll()
        {
            return _serv.GetAll();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public EmpresaDTO Get(int id)
        {
            return _serv.Get(id);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dao"></param>
        /// <returns></returns>
        [HttpPost]
        public EmpresaDTO Post(EmpresaDAO dao)
        {
            return _serv.Add(dao);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dao"></param>
        /// <returns></returns>
        [HttpPut]
        public EmpresaDTO Put(EmpresaDAO dao)
        {
            return _serv.Update(dao, dao.Id);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dao"></param>
        /// <returns></returns>
        [HttpDelete]
        public EmpresaDTO Delete(EmpresaDAO dao)
        {
            return _serv.Delete(dao, dao.Id);
        }
        #endregion
    }
}
