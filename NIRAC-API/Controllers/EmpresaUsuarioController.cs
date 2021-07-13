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
    [RoutePrefix("api/EmpresaUsuario")]
    public class EmpresaUsuarioController : ApiController
    {
        private ContextDb cx;
        private EmpresaUsuarioMap map;
        private EmpresaUsuarioRepository rep;
        private EmpresaUsuarioService _serv;

        public EmpresaUsuarioController() : base()
        {
            this.map = new EmpresaUsuarioMap();
            this.cx = new ContextDb();
            this.rep = new EmpresaUsuarioRepository(cx);
            this._serv = new EmpresaUsuarioService(this.cx, this.rep, this.map);
        }

        [HttpGet]
        public List<EmpresaUsuarioDTO> GetAll()
        {
            return _serv.GetAll();
        }
        [HttpGet]
        public EmpresaUsuarioDTO Get(int id)
        {
            return _serv.Get(id);
        }
        [HttpGet]
        [Route("GetDAO/{id}")]
        public EmpresaUsuarioDAO GetDAO(int id)
        {
            return _serv.GetDAO(id);
        }
        [HttpPost]
        public EmpresaUsuarioDTO Post(EmpresaUsuarioDAO dao)
        {
            return _serv.Add(dao);
        }
        [HttpPut]
        public EmpresaUsuarioDTO Put(EmpresaUsuarioDAO dao)
        {
            return _serv.Update(dao, dao.Id);
        }
        [HttpDelete]
        public EmpresaUsuarioDTO Delete(EmpresaUsuarioDAO dao)
        {
            return _serv.Delete(dao, dao.Id);
        }
    }
}
