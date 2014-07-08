using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Fornecedor
    {
        [Key]
        public virtual int FornecedorId { get; set; }
        public virtual string RazaoSocial { get; set; }
        public virtual string NomeFantasia { get; set; }
        public virtual string Telefone { get; set; }
        public virtual string TelefoneDDD { get; set; }
        public virtual string Celular { get; set; }
        public virtual string CelularDDD { get; set; }
        public virtual string Email { get; set; }
        public virtual string CNPJ { get; set; }
        public virtual string NomeContato { get; set; }
        public virtual string Endereco { get; set; }
        public virtual string Numero { get; set; }
        public virtual string Bairro { get; set; }
        public virtual string Cidade { get; set; }
        public virtual string Estado { get; set; }
        public virtual string CEP { get; set; }

        public virtual string Complemento { get; set; }
    }
}
