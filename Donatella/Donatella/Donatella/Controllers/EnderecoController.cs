using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using Donatella.Helpers;

namespace Donatella.Controllers
{
    public class EnderecoController : Controller
    {
        [HttpPost]
        public async Task<ActionResult> BuscarCep(string cep)
        {
            var retorno = new List<string>();
            cep = TextoHelpers.GetNumeros(cep);

            if (string.IsNullOrEmpty(cep))
                return Json(retorno, JsonRequestBehavior.AllowGet);

            try
            {
                System.Net.ServicePointManager.Expect100Continue = false;
                var obj = new br.com.alquimiacrm.www.Service();
                var endereco = obj.BuscaCEP(cep);

                retorno.Add(endereco.ENDERECO);
                retorno.Add(endereco.BAIRRO);
                retorno.Add(endereco.CIDADE);
                retorno.Add(endereco.UF.ToUpper());
            }
            catch
            { }

            return Json(retorno, JsonRequestBehavior.AllowGet);
        }
    }
}
