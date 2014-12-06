using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Donatella.App.Interface;
using Donatella.Filters;
using Donatella.Helpers;
using Donatella.Models;
using Donatella.Models.Enums;

namespace Donatella.Controllers
{
    public class CadastroController : BaseController
    {
        private readonly IParticipanteApp _participanteApp;
        private readonly ILogApp _logApp;
        private readonly IUsuarioApp _usuarioApp;

        public CadastroController(IParticipanteApp participanteApp, ILogApp logApp, IUsuarioApp usuarioApp)
        {
            _participanteApp = participanteApp;
            _logApp = logApp;
            _usuarioApp = usuarioApp;
        }

        [LogActionFilter]
        public async Task<ActionResult> Cadastro()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<string> SalvarCadastro(CadastroViewModel model)
        {
            try
            {
                if (model.TipoTelaDeCadastro == TipoTelaDeCadastro.MeusDados)
                {
                    _usuarioApp.ValidarSenha(UsuarioLogado.CurrentUser.UserId, model.SenhaAtual);

                    ModelState.Remove("NovaSenha");
                    ModelState.Remove("ConfirmaSenha");
                }

                if (!ModelState.IsValid)
                    throw new Exception(Erro);

                _participanteApp.Salvar(model);
                
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<string> SalvarFoto(HttpPostedFileBase arquivo)
        {
            var retorno = "";

            try
            {
                var sExtensao = arquivo.FileName.Substring(arquivo.FileName.Length - 4);
                var extensaoValida = new[] { ".jpg", ".JPG", ".JPEG", ".bmp", ".BMP", ".gif", ".GIF", ".png", ".PNG" };
                var extensao = (from n in extensaoValida where n.StartsWith(sExtensao) select n).Count();
                if (extensao > 0)
                {
                    var caminhoArquivo = Server.MapPath("~/Arquivos/FotoParticipantes/");
                    var caminhoArquivoOriginal = Server.MapPath("~/temp/FotoParticipantes/");

                    if (!Directory.Exists(caminhoArquivo))
                        Directory.CreateDirectory(caminhoArquivo);

                    if (!Directory.Exists(caminhoArquivoOriginal))
                        Directory.CreateDirectory(caminhoArquivoOriginal);

                    var adicionaNome = DateTime.Now.ToString("ddMMyyyyHHmmss") + sExtensao;
                    arquivo.SaveAs(caminhoArquivoOriginal + adicionaNome);
                    var objImagens = new ImagemHelper(caminhoArquivoOriginal + adicionaNome);
                    objImagens.SaveImage(caminhoArquivo + adicionaNome, 800, 600, 50);
                    objImagens.SaveImage(caminhoArquivo + "thumb_" + adicionaNome, 200, 200);
                    retorno = "{Erro : '', url : 'thumb_" + adicionaNome + "'}";
                }
                else
                    retorno = "{Erro: 'Erro: Arquivo inválido.'}";
            }
            catch (Exception ex)
            {
                retorno = "{Erro: 'Erro: " + ex.Message + "'}";
            }

            return "<script type='text/javascript'>parent.fotoUploaded(" + retorno + ");</script>";
        }
    }
}
