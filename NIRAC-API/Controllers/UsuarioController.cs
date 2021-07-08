using System.Collections.Generic;
using System.Web.Http;
using NIRAC_BUSINESS.Context;
using NIRAC_BUSINESS.DAO;
using NIRAC_BUSINESS.DTO;
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
        private UsuarioService _serv;
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
            return this._serv.GetAll();
        }
        [HttpGet]
        public UsuarioDTO Get(int id)
        {
            return this._serv.Get(id);
        }
        
        [HttpGet]
        [Route("ValidUserPassword/{username}")]
        public UsuarioDTO ValidUserPassword(string username)
        {
            var user = this._serv.GetAll().Find(u => u.Apelido.Equals(username));
            return user;
        }
        [HttpGet]
        [Route("{email}")]
        public UsuarioDTO GetUserbyEmail(string email)
        {
            return this._serv.GetAll().Find(u => u.Email == email);
        }
        [HttpPost]
        public UsuarioDTO Post(UsuarioDAO dao)
        {
            return this._serv.Add(dao);
        }
        [HttpPut]
        public UsuarioDTO Put(UsuarioDAO dao)
        {
            return this._serv.Update(dao);
        }
        [HttpDelete]
        public UsuarioDTO Delete(UsuarioDAO dao)
        {
            return this._serv.Delete(dao);
        }
    }
}
