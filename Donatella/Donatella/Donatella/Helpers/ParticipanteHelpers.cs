using System;

namespace Donatella.Helpers
{
    public class ParticipanteHelpers
    {
        public static string Foto(string foto)
        {
            if (string.IsNullOrEmpty(foto) || foto.Contains("profile-noPhoto.jpg"))
                return "Arquivos/profile-noPhoto.jpg";

            if (foto.StartsWith("Arquivos/"))
                return foto;

            if (foto.StartsWith("FotoParticipantes/"))
                return "Arquivos/" + foto;

            return "Arquivos/FotoParticipantes/" + foto;
        }

        public static string GetCpfCnpjSemZeros(string cpfCnpj)
        {
            cpfCnpj = TextoHelpers.GetNumeros(cpfCnpj);
            while (cpfCnpj.StartsWith("0"))
            {
                cpfCnpj = cpfCnpj.Substring(1);
            }

            return cpfCnpj;
        }

        public static string CnpjLimpo(string cnpj)
        {
            cnpj = TextoHelpers.GetNumeros(cnpj);

            if (string.IsNullOrEmpty(cnpj))
                return "";

            while (cnpj.StartsWith("0"))
                cnpj = cnpj.Substring(1);

            return cnpj;
        }

        public static string CpfLimpo(string cpf)
        {
            cpf = TextoHelpers.GetNumeros(cpf);

            if (string.IsNullOrEmpty(cpf))
                return "";

            while (cpf.StartsWith("0"))
                cpf = cpf.Substring(1);

            return cpf;
        }

        public static string CpfCompleto(string cpf)
        {
            cpf = TextoHelpers.GetNumeros(cpf);

            if (string.IsNullOrEmpty(cpf))
                return "";

            while (cpf.Length < 11)
                cpf = "0" + cpf;

            return cpf;
        }

        public static bool IsCnpj(string cnpj)
        {
            int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int soma;
            int resto;
            string digito;
            string tempCnpj;
            cnpj = cnpj.Trim();
            cnpj = cnpj.Replace(".", "").Replace("-", "").Replace("/", "");
            if (cnpj.Length != 14)
                return false;
            tempCnpj = cnpj.Substring(0, 12);
            soma = 0;
            for (int i = 0; i < 12; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];
            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCnpj = tempCnpj + digito;
            soma = 0;
            for (int i = 0; i < 13; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];
            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();
            return cnpj.EndsWith(digito);
        }

        public static bool IsCpf(Int64 cpf)
        {
            return IsCpf(cpf.ToString());
        }

        public static bool IsCpf(string cpf)
        {
            while (cpf.Length < 11)
            {
                cpf = "0" + cpf;
            }

            int[] multiplicador1 = new int[] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;
            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");
            if (cpf.Length != 11)
                return false;
            tempCpf = cpf.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();
            return cpf.EndsWith(digito);
        }

        public static string GeraToken()
        {
            return Guid.NewGuid().ToString("n");
        }
    }
}