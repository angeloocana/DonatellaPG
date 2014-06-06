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
        public virtual string NomeFuncionario { get; set; }
        public virtual string Telefone { get; set; }
        public virtual string TelefoneDDD { get; set; }
        public virtual string Celular { get; set; }
        public virtual string CelularDDD { get; set; }
        [EmailAddress(ErrorMessage = "Não é um email válido!")]
        [Required(ErrorMessage = "Campo obrigatório!")]
        public virtual string Email { get; set; }
        [Required(ErrorMessage = "Campo obrigatório!")]
        public virtual string CPF { get; set; }
        public virtual byte[] Senha { get; set; }
        public virtual string Endereco { get; set; }
        public virtual string Numero { get; set; }
        public virtual string Bairro { get; set; }
        public virtual string Cidade { get; set; }
        public virtual string Estado { get; set; }
        public virtual string CEP { get; set; }

        public virtual string Complemento { get; set; }

        public bool Ativo { get; set; }

        public virtual ICollection<FuncionarioPermissao> Permissoes { get; set; }
    }
}
