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
    [RoutePrefix("api/EmpresaUsuario")]
    public class EmpresaUsuarioController : ApiController
    {
        private readonly ContextDb cx;
        private readonly EmpresaUsuarioMap map;
        private readonly EmpresaUsuarioRepository rep;
        private readonly EmpresaUsuarioService _serv;
        /// <summary>
        /// 
        /// </summary>
        public EmpresaUsuarioController() : base()
        {
            map = new EmpresaUsuarioMap();
            cx = new ContextDb();
            rep = new EmpresaUsuarioRepository(cx);
            _serv = new EmpresaUsuarioService(cx, rep, map);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="idUsuario"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("BuscaEmpresaUsuarioDTOPeloIdUsuario/{idUsuario}")]
        public EmpresaUsuarioDTO BuscaEmpresaUsuarioDTOPeloIdUsuario(int idUsuario)
        {
            return _serv.GetAll().Find(e => e.IdUsuario == idUsuario);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("BuscaEmpresaUsuarioDAOPeloId/{id}")]
        public EmpresaUsuarioDAO BuscaEmpresaUsuarioDAOPeloId(int id)
        {
            return _serv.GetDAO(id);
        }
        #region CRUD
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<EmpresaUsuarioDTO> GetAll()
        {
            return _serv.GetAll();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public EmpresaUsuarioDTO Get(int id)
        {
            return _serv.Get(id);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dao"></param>
        /// <returns></returns>
        [HttpPost]
        public EmpresaUsuarioDTO Post(EmpresaUsuarioDAO dao)
        {
            return _serv.Add(dao);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dao"></param>
        /// <returns></returns>
        [HttpPut]
        public EmpresaUsuarioDTO Put(EmpresaUsuarioDAO dao)
        {
            return _serv.Update(dao, dao.Id);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dao"></param>
        /// <returns></returns>
        [HttpDelete]
        public EmpresaUsuarioDTO Delete(EmpresaUsuarioDAO dao)
        {
            return _serv.Delete(dao, dao.Id);
        }
        #endregion
    }
}
