namespace NIRAC_BUSINESS.Models.PrivateMethods
{
    public class ToFromGenero
    {
        public string Genero(int genero)
        {
            string retorno = "";
            if (genero == 1)
                retorno = "Masculino";
            if (genero == 2)
                retorno = "Feminino";
            return retorno;
        }
    }
}
