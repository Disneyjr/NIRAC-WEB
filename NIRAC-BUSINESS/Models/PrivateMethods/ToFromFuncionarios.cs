namespace NIRAC_BUSINESS.Models.PrivateMethods
{
    public class ToFromFuncionarios
    {
        public string Funcionario(int funcionario)
        {
            string retorno = "";
            if (funcionario == 1)
                retorno = "Motoboy";
            if (funcionario == 2)
                retorno = "Consultor";
            if (funcionario == 3)
                retorno = "Contador";
            return retorno;
        }
    }
}
