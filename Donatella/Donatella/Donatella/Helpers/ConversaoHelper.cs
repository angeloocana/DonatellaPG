using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Pol.Helpers;

namespace Donatella.Helpers
{
    public class ConversaoHelper
    {
        public static DateTime? ToDateTime(string date)
        {
            DateTime dt;
            DateTime.TryParse(date, out dt);
            return dt > DateTime.MinValue ? dt : (DateTime?)null;
        }

        public static int ToInt(string txt)
        {
            int inteiro;
            int.TryParse(txt, out inteiro);
            return inteiro;
        }
        public static Int64 ToInt64(string txt)
        {
            txt = TextoHelpers.GetNumeros(txt);
            Int64 inteiro;
            Int64.TryParse(txt, out inteiro);
            return inteiro;
        }
        public static Int64 ToCpf(string cpf)
        {
            return ToInt64(ParticipanteHelpers.CpfLimpo(cpf));
        }

        public static int? ToIntWhenErrorNull(string txt)
        {
            try
            {
                return Convert.ToInt32(txt);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static List<int> ToIntList(string txt)
        {
            var ids = txt.Split(',');
            return (from id in ids select ToIntWhenErrorNull(id) into convertido where convertido != null select convertido.Value).ToList();
        }
    }
}