﻿using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace NIRAC_BUSINESS.Models.DAO
{
    [Table("Empresa")]
    public class EmpresaDAO
    {
        [Column("Id")]
        public int Id { get; set; }
        [Column("Nome")]
        public string Nome { get; set; }
        [Column("DinheiroCaixa")]
        public decimal DinheiroCaixa { get; set; }
        [Column("DataCriacao")]
        public DateTime DataCriacao { get; set; }
        [Column("DataAtualizacao")]
        public DateTime DataAtualizacao { get; set; }
        [Column("IdUsuario")]
        public int? IdUsuario { get; set; }
        [ForeignKey("paisDAO")]
        public int? IdPais { get; set; }
        public PaisDAO paisDAO { get; set; }
        [ForeignKey("estadoDAO")]
        public int? IdEstado { get; set; }
        public EstadoDAO estadoDAO { get; set; }
        [ForeignKey("cidadeDAO")]
        public int? IdCidade { get; set; }
        public CidadeDAO cidadeDAO { get; set; }
    }
}
