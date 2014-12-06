using System.Collections.Generic;
using System.Linq;
using Donatella.App.Interface;
using Donatella.Data.Entities;
using Donatella.Models;

namespace Donatella.App.Concrete
{
    public class FaqApp : IFaqApp
    {
        private readonly IRepository<FaqGrupo> _faqGrupoRepository;
        private readonly IRepository<Faq> _faqRepository;

        public FaqApp(IRepository<FaqGrupo> faqgrupoRepository, IRepository<Faq> faqRepository)
        {
            _faqGrupoRepository = faqgrupoRepository;
            _faqRepository = faqRepository;
        }
        
        public void SalvarGrupoFaq(FaqGrupoFormViewModel model)
        {
            var registro = model.Id > 0 ? _faqGrupoRepository.Get(model.Id) : new FaqGrupo();
            registro.Grupo = model.Grupo;
            registro.Ordem = model.Ordem;

            if (registro.Id > 0)
                _faqGrupoRepository.Update(registro);
            else
                _faqGrupoRepository.Add(registro);

            _faqGrupoRepository.Commit();
        }

        public void SalvarFaq(FaqFormViewModel model)
        {
            var _registro = model.Id > 0 ? _faqRepository.Get(model.Id) : new Faq();
            _registro.Pergunta = model.Pergunta;
            _registro.Resposta = model.Resposta;
            _registro.Ordem = model.Ordem;
            _registro.FaqGrupoId = model.FaqGrupoId;
            if (_registro.Id > 0)
                _faqRepository.Update(_registro);
            else
                _faqRepository.Add(_registro);
            _faqRepository.Commit();
        }

        public IEnumerable<FaqViewModel> Faqs()
        {
            return
                from x in _faqRepository.Get()
                select new FaqViewModel()
                {
                    Id = x.Id,
                    FaqGrupo = x.FaqGrupo.Grupo,
                    Ordem = x.Ordem,
                    Pergunta = x.Pergunta,
                    Resposta = x.Resposta
                };
        }

        public IEnumerable<FaqViewModel> Faqs(int faqGrupoId)
        {
            return
              from x in _faqRepository.Get()
              where x.FaqGrupoId == faqGrupoId
              select new FaqViewModel()
              {
                  Ordem = x.Ordem,
                  Pergunta = x.Pergunta,
                  Resposta = x.Resposta,
                  Id = x.Id,
                  FaqGrupo = x.FaqGrupo.Grupo
              };
        }

        public Dictionary<int, string> GruposCombo()
        {
            return
                (from x in _faqGrupoRepository.Get()
                 select new
                 {
                     x.Id,
                     x.Grupo
                 }).ToDictionary(x => x.Id, x => x.Grupo);
        }

        public IEnumerable<FaqGrupoViewModel> Grupos()
        {
            return
                from x in _faqGrupoRepository.Get()
                select new FaqGrupoViewModel
                {
                    Id = x.Id,
                    Grupo = x.Grupo,
                    Ordem = x.Ordem
                };
        }

        public IEnumerable<FaqGrupoViewModel> GruposEFaqs()
        {
            var faqs = (from x in _faqGrupoRepository.Get()
                        where x.DtInativacao == null
                        orderby x.Ordem
                        select new FaqGrupoViewModel
                        {
                            Id = x.Id,
                            Grupo = x.Grupo,
                            Ordem = x.Ordem,
                            Faqs = (from f in x.Faqs
                                    orderby f.Ordem
                                    where f.DtInativacao == null
                                    select new FaqViewModel
                                    {
                                        FaqGrupo = x.Grupo,
                                        Id = f.Id,
                                        Ordem = f.Ordem,
                                        Pergunta = f.Pergunta,
                                        Resposta = f.Resposta
                                    })
                        }).ToList();

            faqs.RemoveAll(f => !f.Faqs.Any());
            return faqs;
        }

        public FaqGrupoFormViewModel Grupo(int id)
        {
            return (from x in _faqGrupoRepository.Get()
                    where x.Id == id
                    select new FaqGrupoFormViewModel
                    {
                        Grupo = x.Grupo,
                        Id = x.Id,
                        Ordem = x.Ordem
                    }).FirstOrDefault();
        }

        public FaqFormViewModel Faq(int id)
        {
            return (
              from x in _faqRepository.Get()
              where x.Id == id
              select new FaqFormViewModel
              {
                  Ordem = x.Ordem,
                  Pergunta = x.Pergunta,
                  Resposta = x.Resposta,
                  Id = x.Id,
                  FaqGrupoId = x.FaqGrupoId
              }).FirstOrDefault();
        }

        public void RemoverFaq(int id)
        {
            var registro = _faqRepository.Get(id);
            if (registro.Id > 0)
            {
                _faqRepository.Delete(registro);
            }
            _faqRepository.Commit();
        }

        public void RemoverFaqGrupo(int id)
        {
            _faqRepository.DeleteAll(_faqRepository.Get().Where(x => x.FaqGrupoId == id));

            var registro = _faqGrupoRepository.Get(id);
            if (registro.Id > 0)
            {
                _faqGrupoRepository.Delete(registro);
            }
            _faqGrupoRepository.Commit();
        }
    }
}