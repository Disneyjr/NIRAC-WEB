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
    [RoutePrefix("api/Emprestimo")]
    public class EmprestimoController : ApiController
    {
        private ContextDb cx;
        private EmprestimoMap map;
        private EmprestimoRepository rep;
        private EmprestimoService _serv;

        public EmprestimoController()
        {
            this.map = new EmprestimoMap();
            this.cx = new ContextDb();
            this.rep = new EmprestimoRepository(cx);
            this._serv = new EmprestimoService(this.cx, this.rep, this.map);
        }
        #region CRUD
        [HttpGet]
        public List<EmprestimoDTO> GetAll()
        {
            return _serv.GetAll();
        }
        [HttpGet]
        public EmprestimoDTO Get(int id)
        {
            return _serv.Get(id);
        }
        [HttpPost]
        public EmprestimoDTO Post(EmprestimoDAO dao)
        {
            return _serv.Add(dao);
        }
        [HttpPut]
        public EmprestimoDTO Put(EmprestimoDAO dao)
        {
            return _serv.Update(dao, dao.Id);
        }
        [HttpDelete]
        public EmprestimoDTO Delete(EmprestimoDAO dao)
        {
            return _serv.Delete(dao, dao.Id);
        }
        #endregion
    }
}
