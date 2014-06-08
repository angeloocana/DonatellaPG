using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DonatellaDomain.Entities
{
    public class Funcionario
    {
        [Key]
        public virtual int FuncionarioId { get; set; }
        
        [Required(ErrorMessage = "Campo obrigatório!")]
        [StringLength(150)]
        public virtual string NomeFuncionario { get; set; }
        
        [StringLength(9)]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Digite somente números!")]
        public virtual string Telefone { get; set; }

        [StringLength(2)]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Digite somente números!")]
        public virtual string TelefoneDDD { get; set; }

        [StringLength(9)]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Digite somente números!")]
        public virtual string Celular { get; set; }

        [StringLength(2)]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Digite somente números!")]
        public virtual string CelularDDD { get; set; }
        
        [EmailAddress(ErrorMessage = "Não é um email válido!")]
        [Required(ErrorMessage = "Campo obrigatório!")]
        [StringLength(150)]
        public virtual string Email { get; set; }
        
        [Required(ErrorMessage = "Campo obrigatório!")]
        [StringLength(11)]
        public virtual string CPF { get; set; }
        
        public virtual byte[] Senha { get; set; }
        
        [StringLength(150)]
        public virtual string Endereco { get; set; }
        
        [StringLength(50)]
        public virtual string Numero { get; set; }
        
        [StringLength(150)]
        public virtual string Bairro { get; set; }
        
        [StringLength(100)]
        public virtual string Cidade { get; set; }
        
        [StringLength(2)]
        public virtual string Estado { get; set; }
        
        [StringLength(8)]
        public virtual string CEP { get; set; }
        
        [StringLength(150)]
        public virtual string Complemento { get; set; }

        public bool Ativo { get; set; }

        public virtual ICollection<FuncionarioPermissao> Permissoes { get; set; }

    }
}
