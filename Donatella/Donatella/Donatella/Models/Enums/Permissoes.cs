using System.ComponentModel.DataAnnotations;

namespace Donatella.Models.Enums
{
    public enum Permissoes
    {
        Site,
        Admin,
        CadastroPerfilPermissoes,
        RelatorioAcesso,
        RelatorioUsuarios,
        CadastroGrupoFaq,
        CadastroFaq,
        [Display(Name = "Cadastrar Usuários")]
        CadastroUsuario,
        [Display(Name = "Cadastrar produtos")]
        CadastrarProduto,
        [Display(Name = "Alterar status do pedido")]
        AlterarStatusPedido,
        [Display(Name = "Cadastrar forma de pagamento")]
        CadastrarFormaDePagamento,
        [Display(Name = "Cadastrar cargos")]
        CadastrarCargos,
        [Display(Name = "Cadastrar categorias")]
        CadastrarCategorias
    }
}