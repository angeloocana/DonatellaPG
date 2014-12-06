using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using AutoMapper;
using Donatella.App.Interface;
using Donatella.Data.Entities;
using Donatella.Helpers;
using Donatella.Models;
using Donatella.Models.Enums;
using Pol.Helpers;

namespace Donatella.App.Concrete
{
    //public class ParticipanteApp : IParticipanteApp
    //{
    //    private readonly IRepository<Participante> _participanteRepository;
    //    private readonly IUsuarioApp _usuarioApp;
    //    private readonly IEnderecoApp _enderecoApp;
    //    private readonly ICargoApp _cargoApp;

    //    public ParticipanteApp(IRepository<Participante> participanteRepository, IUsuarioApp usuarioApp, IEnderecoApp enderecoApp, ICargoApp cargoApp
    //        )
    //    {
    //        _participanteRepository = participanteRepository;
    //        _usuarioApp = usuarioApp;
    //        _enderecoApp = enderecoApp;
    //        _cargoApp = cargoApp;
    //    }
        
    //    private CadastroViewModel MapCadastro(Participante participante)
    //    {
    //        var cadastro = Mapper.Map<Participante, CadastroViewModel>(participante);
    //        return cadastro;
    //    }

    //    public CadastroViewModel Cadastro(int participanteId)
    //    {
    //        var participante = _participanteRepository.Get().FirstOrDefault(x => x.Id == participanteId);

    //        if (participante == null)
    //            throw new Exception("Participante não existe");

    //        var cadastro = MapCadastro(participante);

    //        return cadastro;
    //    }

    //    public void Salvar(CadastroViewModel model)
    //    {
    //        var participante = model.Id > 0 ? _participanteRepository.Get().FirstOrDefault(x => model.Id == x.Id)
    //            : new Participante { };

    //        if (participante == null)
    //            throw new Exception("Participante não existe");

    //        SalvarUsuario(model, participante);
    //        SalvarParticipante(model, participante);
    //    }
        
    //    private void SalvarUsuario(CadastroViewModel model, Participante participante)
    //    {
    //        //var usuario = Mapper.Map<CadastroViewModel, UsuarioFormViewModel>(model);
    //        //usuario.Id = participante.UsuarioId;
    //        //var cpf = ConversaoHelper.ToInt64(model.Cpf);
    //        //usuario.Cpf = participante.Id > 0 ? participante.Usuario.Cpf.ToString() : cpf.ToString();
    //        //participante.UsuarioId = _usuarioApp.Salvar(usuario, false).Id;
    //    }

    //    private void SalvarEndereco(CadastroViewModel model, Participante participante)
    //    {
    //        //if (participante.EnderecoId > 0)
    //        //    model.Endereco.Id = participante.EnderecoId.Value;

    //        //var endereco = _enderecoApp.Salvar(model.Endereco);
    //        //participante.EnderecoId = endereco.Id;
    //        //participante.Endereco = endereco;
    //    }

    //    private void SalvarParticipante(CadastroViewModel model, Participante participante)
    //    {
    //        participante = Mapper.Map(model, participante);

    //        SalvarEndereco(model, participante);
            
    //        if (participante.Id > 0)
    //            _participanteRepository.Update(participante);
    //        else
    //            _participanteRepository.Add(participante);

    //        _participanteRepository.Commit();
    //    }
    //}
}