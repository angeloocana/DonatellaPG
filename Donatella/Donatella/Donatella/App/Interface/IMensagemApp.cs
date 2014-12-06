using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Donatella.App.Interface
{
    public interface IMensagemApp
    {
        void Salvar(int participanteId, string msg);
    }
}
