using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace NIRAC_BUSINESS.Models.DAO
{
    [Table("CentroCusto")]
    public class CentroCustoDAO
    {
        [Column("Id")]
        public int Id { get; set; }
        [Column("Nome")]
        public string Nome { get; set; }
        [Column("Descricao")]
        public string Descricao { get; set; }
        [Column("Saldo")]
        public decimal Saldo { get; set; }
        [Column("DataCriacao")]
        public DateTime DataCriacao { get; set; }
        [Column("DataAtualizacao")]
        public DateTime DataAtualizacao { get; set; }
        [ForeignKey("empresaDAO")]
        public int? IdEmpresa { get; set; }
        public EmpresaDAO empresaDAO { get; set; }
    }
}
