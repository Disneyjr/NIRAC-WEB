using NIRAC_BUSINESS.Models.DTO;
using NIRAC_WEB.WebServices;
using System.Collections.Generic;

namespace NIRAC_WEB.ViewModel
{
    public class EmprestimoVM
    {
        public EmprestimoWebService emprestimoWebService = new EmprestimoWebService();
        public EmprestimoDTO emprestimo = new EmprestimoDTO();
        public List<EmprestimoDTO> listaemprestimos = new List<EmprestimoDTO>();
        public UsuarioDTO cliente = new UsuarioDTO();
        public string GetCliente(EmprestimoDTO emprestimo)
        {
            var cliente = emprestimoWebService.GetCliente(emprestimo.IdCliente);
            return cliente.Nome;
        }
    }
}