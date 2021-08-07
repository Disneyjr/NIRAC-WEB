using NIRAC_BUSINESS.API_CONFIG;
using NIRAC_BUSINESS.Models.DAO;
using NIRAC_BUSINESS.Models.DTO;
using System.Collections.Generic;

namespace NIRAC_WEB.WebServices
{
    public class EmprestimoWebService
    {
        private ApiConfiguration api;
        private WebServiceBase<EmprestimoDAO> _emprestimoBase;
        private WebServiceBase<ParcelaDAO> _parcelaBase;
        private WebServiceBase<EmprestimoDTO> _emprestimoBaseDTO;
        private WebServiceBase<UsuarioDAO> _usuarioBase;
        public EmprestimoWebService()
        {
            this.api = new ApiConfiguration();
            this._parcelaBase = new WebServiceBase<ParcelaDAO>(this.api.URI_API);
            this._emprestimoBase = new WebServiceBase<EmprestimoDAO>(this.api.URI_API);
            this._emprestimoBaseDTO = new WebServiceBase<EmprestimoDTO>(this.api.URI_API);
            this._usuarioBase = new WebServiceBase<UsuarioDAO>(this.api.URI_API);
        }
        public bool Delete(EmprestimoDAO emprestimoDAO, List<ParcelaDAO> parcelas)
        {
            if (parcelas.Count > 0)
            {
                foreach (var parcela in parcelas)
                {
                    var parceladeletada = _parcelaBase.Delete(parcela, parcela.Id, "Parcela");
                    if (parceladeletada == null || parceladeletada.Id == 0 || parceladeletada.Id < 0)
                    {
                        return true;
                    }
                }
            }
            var emprestimodeletado = _emprestimoBase.Delete(emprestimoDAO, emprestimoDAO.Id, "Emprestimo");
            if (emprestimodeletado.Id > 0)
            {
                return true;
            }
            return false;
        }
        public List<UsuarioDAO> GetClientes(int idUsuario)
        {
            return _usuarioBase.GetListFindInt(idUsuario, "Usuario/BuscaClientesPeloIdUsuarioAdm/");
        }
        public List<EmprestimoDTO> GetAll()
        {
            return _emprestimoBaseDTO.GetAll("Emprestimo");
        }
        public bool Add(EmprestimoDAO emprestimo)
        {
            EmprestimoDAO emp = _emprestimoBase.Add(emprestimo, "Emprestimo");
            if (emp.Id > 0)
            {
                foreach (var parcela in emp.parcelas)
                {
                    _parcelaBase.Add(parcela, "Parcela");
                }
                return true;
            }
            else
            {
                return false;
            }
        }
        public UsuarioDAO GetCliente(int idCliente)
        {
            return _usuarioBase.Get(idCliente, "Usuario/");
        }
    }
}