namespace NIRAC_BUSINESS.Models.API_CONFIG
{
    public class HashingSenha
    {
        private static string GetSaltoRandomico()
        {
            return BCrypt.Net.BCrypt.GenerateSalt(12);
        }

        public static string HashSenha(string senha)
        {
            return BCrypt.Net.BCrypt.HashPassword(senha, GetSaltoRandomico());
        }

        public static bool ValidarSenha(string senha, string hashCorreto)
        {
            return BCrypt.Net.BCrypt.Verify(senha, hashCorreto);
        }
    }
}
