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
            return this._serv.GetAll();
        }
        [HttpGet]
        public EmpresaUsuarioDTO Get(int id)
        {
            return this._serv.Get(id);
        }
        [HttpPost]
        public EmpresaUsuarioDTO Post(EmpresaUsuarioDAO dao)
        {
            return this._serv.Add(dao);
        }
        [HttpPut]
        public EmpresaUsuarioDTO Put(EmpresaUsuarioDAO dao)
        {
            return this._serv.Update(dao);
        }
        [HttpDelete]
        public EmpresaUsuarioDTO Delete(EmpresaUsuarioDAO dao)
        {
            return this._serv.Delete(dao);
        }
    }
}
