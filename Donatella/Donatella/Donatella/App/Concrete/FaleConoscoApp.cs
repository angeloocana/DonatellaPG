using System;
using System.Configuration;
using System.Linq;
using AutoMapper;
using Donatella.App.Interface;
using Donatella.Data.Entities;
using Donatella.Helpers;
using Donatella.Models;

namespace Donatella.App.Concrete
{
    public class FaleConoscoApp : IFaleConoscoApp
    {
        private readonly IRepository<FaleConosco> _faleConoscoRepository;
        private readonly IRepository<Usuario> _usuarioRepository;

        public FaleConoscoApp(IRepository<FaleConosco> faleConoscoRepository, IRepository<Usuario> usuarioRepository)
        {
            _faleConoscoRepository = faleConoscoRepository;
            _usuarioRepository = usuarioRepository;
        }

        public FaleConoscoFormViewModel DadosFaleConosco(int participanteId)
        {
            var faleconosco = (from x in _usuarioRepository.Get()
                               where x.Id == participanteId
                               select new FaleConoscoFormViewModel
                               {
                                   Cpf = x.Cpf.ToString(),
                                   Email = x.Email,
                                   Nome = x.Nome
                               }).FirstOrDefault();

            if (faleconosco == null)
                return null;

            faleconosco.Cpf = ParticipanteHelpers.CpfCompleto(faleconosco.Cpf);
            return faleconosco;
        }

        public void SalvarFaleConosco(FaleConoscoFormViewModel model, int? usuarioId)
        {
            var faleConosco = Mapper.Map<FaleConoscoFormViewModel, FaleConosco>(model);

            faleConosco.UsuarioId = usuarioId;
            _faleConoscoRepository.Add(faleConosco);
            _faleConoscoRepository.Commit();

            EnviarEmail(model);
        }

        private void EnviarEmail(FaleConoscoFormViewModel model)
        {
            var html = "<h3>Fale Conosco</h3>";
            html += "<br/> Nome: " + model.Nome;
            html += "<br/> CPF:" + model.Cpf;
            html += "<br/> Telefone:" + model.Telefone;
            html += "<br /> Email: " + model.Email;
            html += "<br /> Assunto: " + model.Assunto;
            html += "<br /> Mensagem: " + model.Mensagem;

            if (!Email.EnviarEmail(ConfigurationManager.AppSettings["EmailFaleConosco"], "Fale Conosco", html, true, "Fale Conosco"))
                throw new Exception("Não foi possivel enviar o email.");

            try
            {
                html = @"Sua mensagem foi recebida com sucesso. Em breve você terá retorno da equipe do fale conosco. <br /> Att Equipe Donatella " + html;
                Email.EnviarEmail(model.Email, "Fale Conosco", html,
                    true, "Fale Conosco");
            }
            catch (Exception)
            {
            }
        }
    }
}