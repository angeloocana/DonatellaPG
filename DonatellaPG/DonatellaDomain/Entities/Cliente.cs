using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DonatellaDomain.Entities
{
    public class Cliente
    {
        [Key]
        public virtual int ClienteId { get; set; }
        [Required(ErrorMessage = "Campo obrigatório!")]
        public virtual string Nome { get; set; }
        [Required(ErrorMessage = "Campo obrigatório!")]
        public virtual string Telefone { get; set; }
        [Required(ErrorMessage = "Campo obrigatório!")]
        public virtual string TelefoneDDD { get; set; }
        public virtual string Celular { get; set; }
        public virtual string CelularDDD { get; set; }
        [EmailAddress(ErrorMessage = "Não é um email válido!")]
        [Required(ErrorMessage = "Campo obrigatório!")]
        public virtual string Email { get; set; }
        [Required(ErrorMessage = "Campo obrigatório!")]
        public virtual string CPF { get; set; }
        [Required(ErrorMessage = "Campo obrigatório!")]
        public virtual byte[] Senha { get; set; }
        [Required(ErrorMessage = "Campo obrigatório!")]
        public virtual string Endereco { get; set; }
        [Required(ErrorMessage = "Campo obrigatório!")]
        public virtual string Numero { get; set; }
        [Required(ErrorMessage = "Campo obrigatório!")]
        public virtual string Bairro { get; set; }
        [Required(ErrorMessage = "Campo obrigatório!")]
        public virtual string Cidade { get; set; }
        [Required(ErrorMessage = "Campo obrigatório!")]
        public virtual string Estado { get; set; }
        [Required(ErrorMessage = "Campo obrigatório!")]
        public virtual string CEP { get; set; }
        public virtual string Complemento { get; set; }
    }
}
