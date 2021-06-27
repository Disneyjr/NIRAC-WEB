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
        private UsuarioService _usu;
        public UsuarioController():base()
        {
            this.map = new UsuarioMap();
            this.cx = new ContextDb();
            this.rep = new UsuarioRepository(cx);
            this._usu = new UsuarioService(this.cx, this.rep, this.map);
        }
        [HttpGet]
        public List<UsuarioDTO> GetAll()
        {
            return this._usu.GetAll();
        }
        [HttpGet]
        public UsuarioDTO Get(int id)
        {
            return this._usu.Get(id);
        }
        
        [HttpGet]
        [Route("{User}/{Password}")]
        public UsuarioDTO GetUserPassword(string User, string Password)
        {
            return this._usu.GetAll().Find(u=>u.Nome ==  User && u.Senha == Password);
        }
        [HttpPost]
        public UsuarioDTO Post(UsuarioDAO dao)
        {
            return this._usu.Add(dao);
        }
        [HttpPut]
        public UsuarioDTO Put(UsuarioDAO dao)
        {
            return this._usu.Update(dao);
        }
        [HttpDelete]
        public UsuarioDTO Delete(UsuarioDAO dao)
        {
            return this._usu.Delete(dao);
        }
    }
}
