using System;
using System.IO;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Donatella.Helpers
{
    public class Excel
    {
        public static void BaixarExcel(GridView excelGridView, string comecoNomeArquivo)
        {
            //Criar um fluxo para gravar o arquivo do Excel
            HttpContext curContext = HttpContext.Current;
            curContext.Response.Clear();
            curContext.Response.AddHeader("content-disposition", "attachment;filename=" + comecoNomeArquivo + "_" + DateTime.Now.ToString("yyyy_MM_dd hh_mm_ss") + ".xls");
            curContext.Response.Charset = "";
            curContext.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            curContext.Response.ContentType = "application/vnd.ms-excel";

            //Renderiza o GridView
            var sw = new StringWriter();
            var htw = new HtmlTextWriter(sw);
            excelGridView.RenderControl(htw);

            var byteArray = Encoding.ASCII.GetBytes(sw.ToString());
            var s = new MemoryStream(byteArray);
            var sr = new StreamReader(s, Encoding.ASCII);

            curContext.Response.Write(sr.ReadToEnd());
            curContext.Response.End();
        }
    }
}