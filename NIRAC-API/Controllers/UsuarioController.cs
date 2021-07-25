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
    [RoutePrefix("api/Usuario")]
    public class UsuarioController : ApiController
    {
        private ContextDb cx;
        private UsuarioMap map;
        private UsuarioRepository rep;
        public UsuarioService _serv;
        public UsuarioController():base()
        {
            this.map = new UsuarioMap();
            this.cx = new ContextDb();
            this.rep = new UsuarioRepository(cx);
            this._serv = new UsuarioService(this.cx, this.rep, this.map);
        }
        [HttpGet]
        [Route("BuscaUsuariosPeloTipoUsuarioEIdUsuario/{tipo}/{id}")]
        public List<UsuarioDTO> BuscaUsuariosPeloTipoUsuarioEIdUsuario(string tipo, int id)
        {
            return _serv.GetAll().FindAll(u => u.Tipo == tipo && u.IdUsuarioAdm == id);
        }
        [HttpGet]
        [Route("BuscaClientesPeloIdUsuarioAdm/{id}")]
        public List<UsuarioDTO> BuscaClientesPeloIdUsuarioAdm(int id)
        {
            return _serv.GetAll().FindAll(u=> u.IdUsuarioAdm == id);
        }
        [HttpGet]
        [Route("BuscaUsuarioPeloApelido/{apelido}")]
        public UsuarioDTO BuscaUsuarioPeloApelido(string apelido)
        {
            return _serv.GetAll().Find(u => u.Apelido == apelido);
        }
        [HttpGet]
        [Route("BuscaUsuarioPeloEmail/{email}")]
        public UsuarioDTO BuscaUsuarioPeloEmail(string email)
        {
            return _serv.GetAll().Find(u => u.Email == email);
        }
        #region CRUD
        [HttpGet]
        public List<UsuarioDTO> GetAll()
        {
            return _serv.GetAll();
        }
        [HttpGet]
        [Route("GetDAO/{id}")]
        public UsuarioDAO GetDAO(int id)
        {
            return _serv.GetDAO(id);
        }
        [HttpGet]
        public UsuarioDTO Get(int id)
        {
            return _serv.Get(id);
        }
        [HttpPost]
        public UsuarioDTO Post(UsuarioDAO dao)
        {
            return _serv.Add(dao);
        }
        [HttpPut]
        public UsuarioDTO Put(UsuarioDAO dao)
        {
            return _serv.Update(dao, dao.Id);
        }
        [HttpDelete]
        public UsuarioDTO Delete(UsuarioDAO dao)
        {
            return _serv.Delete(dao, dao.Id);
        }
        #endregion
    }
}
