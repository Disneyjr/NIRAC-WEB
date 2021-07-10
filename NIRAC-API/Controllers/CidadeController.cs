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
    [RoutePrefix("api/Cidade")]
    public class CidadeController : ApiController
    {
        private ContextDb cx;
        private CidadeMap map;
        private CidadeRepository rep;
        private CidadeService _serv;

        public CidadeController() : base()
        {
            this.map = new CidadeMap();
            this.cx = new ContextDb();
            this.rep = new CidadeRepository(cx);
            this._serv = new CidadeService(this.cx, this.rep, this.map);
        }

        [HttpGet]
        public List<CidadeDTO> GetAll()
        {
            return this._serv.GetAll();
        }
        [HttpGet]
        public CidadeDTO Get(int id)
        {
            return this._serv.Get(id);
        }
        [HttpPost]
        public CidadeDTO Post(CidadeDAO dao)
        {
            return this._serv.Add(dao);
        }
        [HttpPut]
        public CidadeDTO Put(CidadeDAO dao)
        {
            return this._serv.Update(dao, dao.Id);
        }
        [HttpDelete]
        public CidadeDTO Delete(CidadeDAO dao)
        {
            return this._serv.Delete(dao, dao.Id);
        }
    }
}
