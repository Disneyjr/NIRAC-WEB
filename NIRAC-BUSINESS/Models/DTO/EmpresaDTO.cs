using System;
using NIRAC_BUSINESS.Models.DAO;

namespace NIRAC_BUSINESS.Models.DTO
{
    public class EmpresaDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal DinheiroCaixa { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataAtualizacao { get; set; }
        public int? IdUsuario { get; set; }
        public int? IdPais { get; set; }
        public PaisDAO paisDAO { get; set; }
        public int? IdEstado { get; set; }
        public EstadoDAO estadoDAO { get; set; }
        public int? IdCidade { get; set; }
        public CidadeDAO cidadeDAO { get; set; }
    }
}
