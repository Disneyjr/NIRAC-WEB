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
    [RoutePrefix("api/CentroCusto")]
    public class CentroCustoController : ApiController
    {
        private ContextDb cx;
        private CentroCustoMap map;
        private CentroCustoRepository rep;
        private CentroCustoService _serv;

        public CentroCustoController() : base()
        {
            this.map = new CentroCustoMap();
            this.cx = new ContextDb();
            this.rep = new CentroCustoRepository(cx);
            this._serv = new CentroCustoService(this.cx, this.rep, this.map);
        }

        [HttpGet]
        public List<CentroCustoDTO> GetAll()
        {
            return _serv.GetAll();
        }
        [HttpGet]
        public CentroCustoDTO Get(int id)
        {
            return _serv.Get(id);
        }
        [HttpGet]
        [Route("GetDAO/{id}")]
        public CentroCustoDAO GetDAO(int id)
        {
            return _serv.GetDAO(id);
        }
        [HttpPost]
        public CentroCustoDTO Post(CentroCustoDAO dao)
        {
            return _serv.Add(dao);
        }
        [HttpPut]
        public CentroCustoDTO Put(CentroCustoDAO dao)
        {
            return _serv.Update(dao, dao.Id);
        }
        [HttpDelete]
        public CentroCustoDTO Delete(CentroCustoDAO dao)
        {
            return _serv.Delete(dao, dao.Id);
        }
    }
}
