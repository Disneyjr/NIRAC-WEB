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
            return this._serv.GetAll();
        }
        [HttpGet]
        public CentroCustoDTO Get(int id)
        {
            return this._serv.Get(id);
        }
        [HttpPost]
        public CentroCustoDTO Post(CentroCustoDAO dao)
        {
            return this._serv.Add(dao);
        }
        [HttpPut]
        public CentroCustoDTO Put(CentroCustoDAO dao)
        {
            return this._serv.Update(dao);
        }
        [HttpDelete]
        public CentroCustoDTO Delete(CentroCustoDAO dao)
        {
            return this._serv.Delete(dao);
        }
    }
}
