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
        public string CPF { get; set; }
        public string Genero { get; set; }
        public string EstadoCivil { get; set; }
        public string Senha { get; set; }
        public DateTime Data_Cadastro { get; set; }
        public DateTime Data_Update { get; set; }
        public int? IdCidade { get; set; }
        public int? IdEstado { get; set; }
        public int? IdPais { get; set; }
    }
}
