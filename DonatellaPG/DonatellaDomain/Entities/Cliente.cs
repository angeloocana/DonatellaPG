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
        public virtual string Nome { get; set; }
        public virtual string Telefone { get; set; }
        public virtual string TelefoneDDD { get; set; }
        public virtual string Celular { get; set; }
        public virtual string CelularDDD { get; set; }
        public virtual string Email { get; set; }
        public virtual string CPF { get; set; }
        public virtual byte[] Senha { get; set; }
        public virtual string Endereco { get; set; }
        public virtual string Numero { get; set; }
        public virtual string Bairro { get; set; }
        public virtual string Cidade { get; set; }
        public virtual string Estado { get; set; }
        public virtual string CEP { get; set; }
    }
}
