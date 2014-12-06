using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Donatella.Data.Entities;
using Donatella.Models;

namespace Donatella.App.Interface
{
    public interface IFaleConoscoApp
    {
        void SalvarFaleConosco(FaleConoscoFormViewModel model, int? participanteId);
        FaleConoscoFormViewModel DadosFaleConosco(int participanteId);
    }
}
