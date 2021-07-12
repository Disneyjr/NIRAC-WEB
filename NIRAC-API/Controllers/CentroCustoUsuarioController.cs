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
    [RoutePrefix("api/CentroCustoUsuario")]
    public class CentroCustoUsuarioController : ApiController
    {
        private ContextDb cx;
        private CentroCustoUsuarioMap map;
        private CentroCustoUsuarioRepository rep;
        private CentroCustoUsuarioService _serv;

        public CentroCustoUsuarioController() : base()
        {
            this.map = new CentroCustoUsuarioMap();
            this.cx = new ContextDb();
            this.rep = new CentroCustoUsuarioRepository(cx);
            this._serv = new CentroCustoUsuarioService(this.cx, this.rep, this.map);
        }

        [HttpGet]
        public List<CentroCustoUsuarioDTO> GetAll()
        {
            return _serv.GetAll();
        }
        [HttpGet]
        public CentroCustoUsuarioDTO Get(int id)
        {
            return _serv.Get(id);
        }
        [HttpPost]
        public CentroCustoUsuarioDTO Post(CentroCustoUsuarioDAO dao)
        {
            return _serv.Add(dao);
        }
        [HttpPut]
        public CentroCustoUsuarioDTO Put(CentroCustoUsuarioDAO dao)
        {
            return _serv.Update(dao, dao.Id);
        }
        [HttpDelete]
        public CentroCustoUsuarioDTO Delete(CentroCustoUsuarioDAO dao)
        {
            return _serv.Delete(dao, dao.Id);
        }
    }
}
