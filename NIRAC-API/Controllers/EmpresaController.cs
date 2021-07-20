using System;
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
    [RoutePrefix("api/Empresa")]
    public class EmpresaController : ApiController
    {
        private ContextDb cx;
        private EmpresaMap map;
        private EmpresaRepository rep;
        private EmpresaService _serv;

        public EmpresaController() : base()
        {
            this.map = new EmpresaMap();
            this.cx = new ContextDb();
            this.rep = new EmpresaRepository(cx);
            this._serv = new EmpresaService(this.cx, this.rep, this.map);
        }
        [HttpGet]
        [Route("GetDAO/{id}")]
        public EmpresaDAO GetDAO(int id)
        {
            return _serv.GetDAO(id);
        }
        [HttpGet]
        [Route("EmpresaCadastrada/{idUsuario}")]
        public EmpresaDTO EmpresaCadastrada(int idUsuario)
        {
            return _serv.GetAll().Find(e=>e.IdUsuarioAdm == idUsuario);
        }
        #region CRUD
        [HttpGet]
        public List<EmpresaDTO> GetAll()
        {
            return _serv.GetAll();
        }
        [HttpGet]
        public EmpresaDTO Get(int id)
        {
            return _serv.Get(id);
        }
        [HttpPost]
        public EmpresaDTO Post(EmpresaDAO dao)
        {
            return _serv.Add(dao);
        }
        [HttpPut]
        public EmpresaDTO Put(EmpresaDAO dao)
        {
            return _serv.Update(dao, dao.Id);
        }
        [HttpDelete]
        public EmpresaDTO Delete(EmpresaDAO dao)
        {
            return _serv.Delete(dao, dao.Id);
        }
        #endregion
    }
}
