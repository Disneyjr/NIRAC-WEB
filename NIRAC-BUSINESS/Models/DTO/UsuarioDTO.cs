namespace NIRAC_BUSINESS.DTO
{
    public class UsuarioDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Tipo { get; set; }
        public string CPF { get; set; }
        public string Genero { get; set; }
        public string EstadoCivil { get; set; }
        public string Senha { get; set; }
        public int? IdCidade { get; set; }
        public int? IdEstado { get; set; }
        public int? IdPais { get; set; }
    }
}
