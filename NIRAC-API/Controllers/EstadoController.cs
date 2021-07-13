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
        [Route("EstadosIdPais/{idPais}")]
        public List<EstadoDTO> EstadosIdPais(int idPais)
        {
            return _serv.GetAll().FindAll(e=>e.IdPais == idPais);
        }
        [HttpGet]
        public List<EstadoDTO> GetAll()
        {
            return _serv.GetAll();
        }
        [HttpGet]
        public EstadoDTO Get(int id)
        {
            return _serv.Get(id);
        }
        [HttpGet]
        [Route("GetDAO/{id}")]
        public EstadoDAO GetDAO(int id)
        {
            return _serv.GetDAO(id);
        }
        [HttpPost]
        public EstadoDTO Post(EstadoDAO dao)
        {
            return _serv.Add(dao);
        }
        [HttpPut]
        public EstadoDTO Put(EstadoDAO dao)
        {
            return _serv.Update(dao, dao.Id);
        }
        [HttpDelete]
        public EstadoDTO Delete(EstadoDAO dao)
        {
            return _serv.Delete(dao, dao.Id);
        }
    }
}
