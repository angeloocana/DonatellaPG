using Donatella.Models;

namespace Donatella.App.Interface
{
    public interface IParticipanteApp
    {
        void Salvar(CadastroViewModel model);
        CadastroViewModel Cadastro(int participanteId);
    }
}