using System;

namespace NIRAC_BUSINESS.Models.DTO
{
    public class EmprestimoDTO
    {
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public int IdCliente { get; set; }
        public decimal TotalEmprestimo { get; set; }
        public decimal TotalHaver { get; set; }
        public int QuantidadeParcela { get; set; }
        public decimal PorcentagemJuros { get; set; }
        public int DiaPagamento { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataAtualizacao { get; set; }
        public DateTime DataUltimoPagamento { get; set; }
    }
}
