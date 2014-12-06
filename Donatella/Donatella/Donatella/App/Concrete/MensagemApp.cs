using System;
using System.Linq;
using Donatella.App.Interface;
using Donatella.Data.Entities;

namespace Donatella.App.Concrete
{
    public class MensagemApp : IMensagemApp
    {
        private readonly IRepository<Mensagem> _mensagemRepository;

        public MensagemApp(IRepository<Mensagem> mensagemRepository)
        {
            _mensagemRepository = mensagemRepository;
        }
        public void Salvar(int usuarioId, string msg)
        {
            var mensagem = new Mensagem
            {
                UsuarioId = usuarioId,
                TxtMensagem = msg,
                DtInclusao = DateTime.Now
            };
            Salvar(mensagem);
        }

        public void Salvar(Mensagem mensagem)
        {
            var ontem = DateTime.Now.AddDays(-1);
            var ultimaMensagemIgual = _mensagemRepository.Get().Any(x =>
                                           x.TxtMensagem == mensagem.TxtMensagem
                                           && x.UsuarioId == mensagem.UsuarioId
                                           && x.DtInclusao > ontem);

            if (ultimaMensagemIgual)
                return;

            _mensagemRepository.Add(mensagem);
            _mensagemRepository.Commit();
        }
    }
}