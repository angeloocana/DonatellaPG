using System.ComponentModel.DataAnnotations;
using Donatella.Models.Enums;

namespace Donatella.Data.Entities
{
    public class Endereco : EntityBase
    {
        [MaxLength(150), Display(Name = "Endereço"), Required]
        public virtual string Logradouro { get; set; }

        [MaxLength(150)]
        public virtual string Complemento { get; set; }

        [MaxLength(50), Display(Name = "Número"), Required]
        public virtual string Numero { get; set; }

        [MaxLength(150), Required]
        public virtual string Bairro { get; set; }

        [MaxLength(150), Required]
        public virtual string Cidade { get; set; }

        [DataType("Uf"), Display(Name = "Estado"), Required]
        public virtual Uf? Uf { get; set; }

        [MaxLength(12), Display(Name = "CEP"), Required]
        public virtual string Cep { get; set; }

        public virtual int? ParticipanteIdOldDbs { get; set; }

        public override string ToString()
        {
            return Logradouro + ", " + Numero + " - " + Complemento + " <br /> " + Bairro + " - " + Cidade + "/" + Uf;
        }
    }
}