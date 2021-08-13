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
    /// Usuario Controller
    /// </summary>
    [RoutePrefix("api/Usuario")]
    public class UsuarioController : ApiController
    {
        private readonly ContextDb cx;
        private readonly UsuarioMap map;
        private readonly UsuarioRepository rep;
        /// <summary>
        /// 
        /// </summary>
        public UsuarioService _serv;
        /// <summary>
        /// 
        /// </summary>
        public UsuarioController():base()
        {
            map = new UsuarioMap();
            cx = new ContextDb();
            rep = new UsuarioRepository(cx);
            _serv = new UsuarioService(cx, rep, map);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tipo"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("BuscaUsuariosPeloTipoUsuarioEIdUsuario/{tipo}/{id}")]
        public List<UsuarioDTO> BuscaUsuariosPeloTipoUsuarioEIdUsuario(string tipo, int id)
        {
            return _serv.GetAll().FindAll(u => u.Tipo == tipo && u.IdUsuarioAdm == id);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("BuscaClientesPeloIdUsuarioAdm/{id}")]
        public List<UsuarioDTO> BuscaClientesPeloIdUsuarioAdm(int id)
        {
            return _serv.GetAll().FindAll(u=> u.IdUsuarioAdm == id);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="apelido"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("BuscaUsuarioPeloApelido/{apelido}")]
        public UsuarioDTO BuscaUsuarioPeloApelido(string apelido)
        {
            return _serv.GetAll().Find(u => u.Apelido == apelido);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("BuscaUsuarioPeloEmail/{email}")]
        public UsuarioDTO BuscaUsuarioPeloEmail(string email)
        {
            return _serv.GetAll().Find(u => u.Email == email);
        }
        #region CRUD
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<UsuarioDTO> GetAll()
        {
            return _serv.GetAll();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetDAO/{id}")]
        public UsuarioDAO GetDAO(int id)
        {
            return _serv.GetDAO(id);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public UsuarioDTO Get(int id)
        {
            return _serv.Get(id);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dao"></param>
        /// <returns></returns>
        [HttpPost]
        public UsuarioDTO Post(UsuarioDAO dao)
        {
            return _serv.Add(dao);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dao"></param>
        /// <returns></returns>
        [HttpPut]
        public UsuarioDTO Put(UsuarioDAO dao)
        {
            return _serv.Update(dao, dao.Id);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dao"></param>
        /// <returns></returns>
        [HttpDelete]
        public UsuarioDTO Delete(UsuarioDAO dao)
        {
            return _serv.Delete(dao, dao.Id);
        }
        #endregion
    }
}
