namespace ValidacaoCPF
{
    public static class Cpf
    {
        private const int QTD_CARACTERES_DIG_CPF = 2;

        public static bool Validar(string? cpf)
        {
            if (string.IsNullOrEmpty(cpf) || cpf.Length < 11)
                return false;

            return DigitoEhValido(cpf);
        }

        private static bool DigitoEhValido(string cpf)
        {
            return PrimeiroDigitoEhValido(cpf) && SegundoDigitoEhValido(cpf);
        }

        private static bool PrimeiroDigitoEhValido(string cpf)
        {
            var somaNumerosCpf = 0;
            var contador = 10;
            for (var i = 0 ; i <= cpf.Length - (QTD_CARACTERES_DIG_CPF + 1); i++)
            {
                somaNumerosCpf += int.Parse(cpf[i].ToString()) * contador;
                contador--;
            }

            var restoDivisao = CalcularRestoDivisao(somaNumerosCpf, cpf.Length);
            var digitosCpf = RetornarDigitoCpf(cpf);

            return int.Parse(digitosCpf[0].ToString()) == restoDivisao;
        }

        private static bool SegundoDigitoEhValido(string cpf)
        {
            var somaNumerosCpf = 0;
            var contador = 11;
            for (var i = 0; i <= cpf.Length - QTD_CARACTERES_DIG_CPF; i++)
            {
                somaNumerosCpf += int.Parse(cpf[i].ToString()) * contador;
                contador--;
            }

            var restoDivisao = CalcularRestoDivisao(somaNumerosCpf, cpf.Length);
            var digitosCpf = RetornarDigitoCpf(cpf);

            return int.Parse(digitosCpf[1].ToString()) == restoDivisao;
        }

        private static string RetornarDigitoCpf(string cpf)
        {
            return cpf.Substring(cpf.Length - QTD_CARACTERES_DIG_CPF, QTD_CARACTERES_DIG_CPF);
        }

        private static int CalcularRestoDivisao(int num1, int num2)
        {
            var restoDivisao = num1 * 10 % num2;
            return restoDivisao == 10 ? 0 : restoDivisao;
        }
    }
}
