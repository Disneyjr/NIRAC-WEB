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
    [RoutePrefix("api/Estado")]
    public class EstadoController : ApiController
    {
        private ContextDb cx;
        private EstadoMap map;
        private EstadoRepository rep;
        private EstadoService _serv;

        public EstadoController() : base()
        {
            this.map = new EstadoMap();
            this.cx = new ContextDb();
            this.rep = new EstadoRepository(cx);
            this._serv = new EstadoService(this.cx, this.rep, this.map);
        }

        [HttpGet]
        public List<EstadoDTO> GetAll()
        {
            return this._serv.GetAll();
        }
        [HttpGet]
        public EstadoDTO Get(int id)
        {
            return this._serv.Get(id);
        }
        [HttpPost]
        public EstadoDTO Post(EstadoDAO dao)
        {
            return this._serv.Add(dao);
        }
        [HttpPut]
        public EstadoDTO Put(EstadoDAO dao)
        {
            return this._serv.Update(dao);
        }
        [HttpDelete]
        public EstadoDTO Delete(EstadoDAO dao)
        {
            return this._serv.Delete(dao);
        }
    }
}
