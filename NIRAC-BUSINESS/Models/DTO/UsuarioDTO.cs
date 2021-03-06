using System;

namespace NIRAC_BUSINESS.Models.DTO
{
    public class UsuarioDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Apelido { get; set; }
        public string Email { get; set; }
        public string Tipo { get; set; }
        public string TipoAcesso { get; set; }
        public string Status { get; set; }
        public string CPF { get; set; }
        public string Genero { get; set; }
        public string EstadoCivil { get; set; }
        public string Senha { get; set; }
        public string RG { get; set; }
        public string Telefone { get; set; }
        public string Endereco { get; set; }
        public string Observacao { get; set; }
        public DateTime Data_Cadastro { get; set; }
        public DateTime Data_Update { get; set; }
        public string Indicacao { get; set; }
        public int? IdUsuarioAdm { get; set; }
        public int? IdCidade { get; set; }
        public int? IdEstado { get; set; }
        public int? IdPais { get; set; }
    }
}
