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
        [HttpGet]
        [Route("GetUserType/{type}")]
        public List<UsuarioDTO> GetUserType(string type)
        {
            return _serv.GetAll().FindAll(u => u.Tipo == type);
        }
        [HttpGet]
        [Route("ValidUserPassword/{username}")]
        public UsuarioDTO ValidUserPassword(string username)
        {
            return _serv.GetAll().Find(u => u.Apelido == username);
        }
        [HttpGet]
        [Route("GetUserbyEmail/{email}")]
        public UsuarioDTO GetUserbyEmail(string email)
        {
            return _serv.GetAll().Find(u => u.Email == email);
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
    }
}
