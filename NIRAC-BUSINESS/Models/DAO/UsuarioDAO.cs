using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NIRAC_BUSINESS.Models.DAO
{
    [Table("Usuario")]
    public class UsuarioDAO
    {
        [Column("Id"), Key]
        public int Id { get; set; }
        [Column("Nome")]
        public string Nome { get; set; }  
        [Column("Apelido")]
        public string Apelido { get; set; }
        [Column("Email")]
        public string Email { get; set; }
        [Column("Tipo")]
        public string Tipo { get; set; }
        [Column("TipoAcesso")]
        public string TipoAcesso { get; set; }
        [Column("Status")]
        public string Status { get; set; }
        [Column("CPF")]
        public string CPF { get; set; }
        [Column("Genero")]
        public string Genero { get; set; }
        [Column("EstadoCivil")]
        public string EstadoCivil { get; set; }
        [Column("Senha")]
        public string Senha { get; set; }
        [Column("RG")]
        public string RG { get; set; }
        [Column("Telefone")]
        public string Telefone { get; set; }
        [Column("Endereco")]
        public string Endereco { get; set; }
        [Column("Observacao")]
        public string Observacao { get; set; }
        [Column("Data_Cadastro")]
        public DateTime Data_Cadastro { get; set; }
        [Column("Data_Update")]
        public DateTime Data_Update { get; set; }
        [Column("IdUsuarioAdm")]
        public int? IdUsuarioAdm { get; set; }
        [Column("Indicacao")]
        public string Indicacao { get; set; }
        [Column("IdCidade")]
        public int? IdCidade { get; set; }

        [Column("IdEstado")]
        public int? IdEstado { get; set; }

        [Column("IdPais")]
        public int? IdPais { get; set; }

    }
}
