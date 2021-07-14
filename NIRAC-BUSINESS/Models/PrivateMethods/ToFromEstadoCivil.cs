namespace NIRAC_BUSINESS.Models.PrivateMethods
{
    public class ToFromEstadoCivil
    {
        public string EstadoCivil(int estadocivil)
        {
            string retorno = "";
            if (estadocivil == 1)
                retorno = "Solteiro";
            if (estadocivil == 2)
                retorno = "Casado";
            if (estadocivil == 3)
                retorno = "Separado";
            if (estadocivil == 4)
                retorno = "Divorciado";
            if (estadocivil == 5)
                retorno = "Viúvo";
            return retorno;
        }
    }
}
