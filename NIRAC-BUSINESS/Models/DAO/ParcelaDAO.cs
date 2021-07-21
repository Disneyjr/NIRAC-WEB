using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace NIRAC_BUSINESS.Models.DAO
{
    [Table("Parcela")]
    public class ParcelaDAO
    {
        [Column("Id")]
        public int Id { get; set; }
        [Column("IdEmprestimo")]
        public int? IdEmprestimo { get; set; }
        [Column("Valor")]
        public decimal Valor { get; set; }
        [Column("ValorPago")]
        public decimal ValorPago { get; set; }
        [Column("ValorRestanteParcela")]
        public decimal ValorRestanteParcela { get; set; }
        [Column("DataCriacao")]
        public DateTime DataCriacao { get; set; }
        [Column("DataAtualizacao")]
        public DateTime DataAtualizacao { get; set; }
    }
}
