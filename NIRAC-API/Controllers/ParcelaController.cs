using NIRAC_BUSINESS.Context;
using NIRAC_BUSINESS.Models.DAO;
using NIRAC_BUSINESS.Models.DTO;
using NIRAC_BUSINESS.Models.Map;
using NIRAC_BUSINESS.Repository;
using NIRAC_BUSINESS.Services;
using System.Collections.Generic;
using System.Web.Http;

namespace NIRAC_API.Controllers
{
    [RoutePrefix("api/Parcela")]
    public class ParcelaController : ApiController
    {
        private ContextDb cx;
        private ParcelaMap map;
        private ParcelaRepository rep;
        private ParcelaService _serv;

        public ParcelaController()
        {
            this.map = new ParcelaMap();
            this.cx = new ContextDb();
            this.rep = new ParcelaRepository(cx);
            this._serv = new ParcelaService(this.cx, this.rep, this.map);
        }
        #region CRUD
        [HttpGet]
        public List<ParcelaDTO> GetAll()
        {
            return _serv.GetAll();
        }
        [HttpGet]
        public ParcelaDTO Get(int id)
        {
            return _serv.Get(id);
        }
        [HttpPost]
        public ParcelaDTO Post(ParcelaDAO dao)
        {
            return _serv.Add(dao);
        }
        [HttpPut]
        public ParcelaDTO Put(ParcelaDAO dao)
        {
            return _serv.Update(dao, dao.Id);
        }
        [HttpDelete]
        public ParcelaDTO Delete(ParcelaDAO dao)
        {
            return _serv.Delete(dao, dao.Id);
        }
        #endregion
    }
}
