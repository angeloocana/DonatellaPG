using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Donatella.Models.Relatorios
{
    public class RelatorioDeParticipanteViewModel
    {
        public string Nome { get; set; }
        public string Participante { get; set; }
        public string Cargo { get; set; }
        public string Email { get; set; }
        public string Rg { get; set; }
        public Int64 Cpf { get; set; }
        public string DtNascimento { get; set; }
        public string Uf { get; set; }
        public string Sexo { get; set; }
        public string EstadoCivil { get; set; }
        public string Endereco { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Cep { get; set; }
        public string TelCelularDdd { get; set; }
        public string TelCelular { get; set; }
        public string TelResidencial { get; set; }
        public string TelResidencialDdd { get; set; }
    }
}