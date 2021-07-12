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
    [RoutePrefix("api/Pais")]
    public class PaisController : ApiController
    {
        private ContextDb cx;
        private PaisMap map;
        private PaisRepository rep;
        private PaisService _serv;

        public PaisController():base()
        {
            this.map = new PaisMap();
            this.cx = new ContextDb();
            this.rep = new PaisRepository(cx);
            this._serv = new PaisService(this.cx, this.rep, this.map);
        }
        #region CRUD
        [HttpGet]
        public List<PaisDTO> GetAll()
        {
            return _serv.GetAll();
        }
        [HttpGet]
        public PaisDTO Get(int id)
        {
            return _serv.Get(id);
        }
        [HttpPost]
        public PaisDTO Post(PaisDAO dao)
        {
            return _serv.Add(dao);
        }
        [HttpPut]
        public PaisDTO Put(PaisDAO dao)
        {
            return _serv.Update(dao, dao.Id);
        }
        [HttpDelete]
        public PaisDTO Delete(PaisDAO dao)
        {
            return _serv.Delete(dao, dao.Id);
        }
        #endregion
    }
}
