using System;

namespace NIRAC_BUSINESS.Models.DTO
{
    public class ParcelaDTO
    {
        public int Id { get; set; }
        public int IdEmprestimo { get; set; }
        public decimal Valor { get; set; }
        public decimal ValorPago { get; set; }
        public decimal ValorRestanteParcela { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataAtualizacao { get; set; }
    }
}
