using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DonatellaDomain.Entities
{
    public enum Permissao
    {
        [Display(Name = "Cadastrar funcionários")]
        CadastrarFuncionario,
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
