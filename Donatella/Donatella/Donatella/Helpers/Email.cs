using System.Configuration;
using System.Net.Mail;

namespace Donatella.Models
{
    public class Email
    {
        public static bool EnviarEmail(string email, string titulo, string mensagem, bool HTML, string origem)
        {
            try
            {


//                var Mail = new EnviarEmail.Email();

//#if DEBUG
//                //return true;
//                email = "angeloocana@gmail.com";
//                Mail.To.Add("eduardolevi82@gmail.com");
//                Mail.To.Add("angelo.martins@bpm140.com.br");
//                Mail.To.Add("eduardo.levi@bpm140.com.br");
//                Mail.To.Add("mm82.ch@hotmail.com");
//#endif
//                Mail.To.Add(email);
//                Mail.Subject = titulo;
//                Mail.From = new MailAddress(ConfigurationManager.AppSettings["EmailFaleConosco"], "Donatella");
//                Mail.Body = mensagem;
//                Mail.IsBodyHtml = HTML;
//                Mail.Action = origem;

//                Mail.Send();

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}