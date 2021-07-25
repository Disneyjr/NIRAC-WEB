using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace NIRAC_BUSINESS.Models.DAO
{
    [Table("Emprestimo")]
    public class EmprestimoDAO
    {
        [Column("Id")]
        public int Id { get; set; }
        [Column("IdUsuario")]
        public int? IdUsuario { get; set; }
        [Column("IdCliente")]
        public int? IdCliente { get; set; }
        [Column("TotalEmprestimo")]
        public decimal TotalEmprestimo { get; set; }
        [Column("TotalHaver")]
        public decimal TotalHaver { get; set; }
        [Column("QuantidadeParcela")]
        public int? QuantidadeParcela { get; set; }
        [Column("PorcentagemJuros")]
        public decimal PorcentagemJuros { get; set; }
        [Column("DiaPagamento")]
        public int? DiaPagamento { get; set; }
        [Column("DiaCobranca")]
        public int? DiaCobranca { get; set; }
        [Column("DataCriacao")]
        public DateTime DataCriacao { get; set; }
        [Column("DataAtualizacao")]
        public DateTime DataAtualizacao { get; set; }
        [Column("DataUltimoPagamento")]
        public DateTime DataUltimoPagamento { get; set; }
    }
}
