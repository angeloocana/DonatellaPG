using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using Donatella.App.Interface;
using Donatella.Data.Entities;
using Donatella.Helpers;
using Donatella.Models.Enums;
using Donatella.Models.Relatorios;

namespace Donatella.App.Concrete
{
    //public class RelatorioDeParticipanteApp : IRelatorioDeParticipanteApp
    //{
    //    private readonly IRepository<Usuario> _usuarioRepository;

    //    public RelatorioDeParticipanteApp(IRepository<Usuario> usuarioRepository)
    //    {
    //        _usuarioRepository = usuarioRepository;
    //    }

    //    private readonly IRepository<Participante> _participanteRepository;

    //    public IEnumerable<RelatorioDeParticipanteViewModel> RelatorioDeParticipante(RelatorioDeParticipanteFormViewModel model)
    //    {
    //        return (from x in _usuarioRepository.Get()
    //                where
    //              (string.IsNullOrEmpty(model.Nome) || x.Nome.Contains(model.Nome))
    //              && (model.DtNascimento == null || x.DtNascimento == model.DtNascimento)
    //              && (string.IsNullOrEmpty(model.Email) || x.Email.Contains(model.Email))
    //              && (model.Cpf == null || x.Cpf == model.Cpf)
    //              && (model.Uf == null || x.Endereco.Uf == model.Uf)
    //              && (model.CargoId == null || x.CargoId == model.CargoId)
    //              && (model.Sexo == null || x.Sexo == model.Sexo)
    //                select new
    //          {
    //              x.Email,
    //              x.Nome,
    //              x.Cpf,
    //              Cargo = x.Cargo.NomeCargo,
    //              x.DtNascimento,
    //              x.Sexo,
    //              x.Endereco.Uf,
    //              x.Endereco.Bairro,
    //              x.TelCelularDdd,
    //              x.TelCelular,
    //              x.TelResidencial,
    //              x.TelResidencialDdd,
    //              x.Endereco.Cep,
    //              x.Endereco.Cidade,
    //              x.Endereco.Complemento,
    //              x.Endereco.Logradouro,
    //              x.Endereco.Numero
    //          }).ToList().Select(x => new RelatorioDeParticipanteViewModel
    //          {
    //              Email = x.Email,
    //              Nome = x.Nome,
    //              Cpf = x.Cpf,
    //              Cargo = x.Cargo,
    //              DtNascimento = x.DtNascimento == null ? "" : x.DtNascimento.Value.ToString("dd/MM/yyyy"),
    //              Participante = x.Nome,
    //              Sexo = x.Sexo == null ? "" : x.Sexo.Value.ToString(),
    //              Uf = x.Uf.ToString(),
    //              Bairro = x.Bairro,
    //              TelCelularDdd = x.TelCelularDdd,
    //              TelCelular = x.TelCelular,
    //              TelResidencial = x.TelResidencial,
    //              TelResidencialDdd = x.TelResidencialDdd,
    //              Cep = x.Cep,
    //              Cidade = x.Cidade,
    //              Complemento = x.Complemento,
    //              Endereco = x.Logradouro,
    //              Estado = x.Uf.ToString(),
    //              Numero = x.Numero
    //          });
    //    }
    //}
}
