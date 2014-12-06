using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Donatella.Models;
using Donatella.Models.Enums;

namespace Donatella.App.Interface
{
    public interface IFaqApp
    {
        void SalvarGrupoFaq(FaqGrupoFormViewModel model);
        void SalvarFaq(FaqFormViewModel model);
        void RemoverFaqGrupo(int id);
        void RemoverFaq(int id);
        FaqGrupoFormViewModel Grupo(int id);
        IEnumerable<FaqGrupoViewModel> Grupos();
        IEnumerable<FaqViewModel> Faqs(int id);
        FaqFormViewModel Faq(int id);
        IEnumerable<FaqViewModel> Faqs();
        IEnumerable<FaqGrupoViewModel> GruposEFaqs();
        Dictionary<int, string> GruposCombo();
    }
}