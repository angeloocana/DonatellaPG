using System;
using System.Linq;
using Donatella.App.Interface;
using Donatella.Data.Entities;
using Pol.Helpers;

namespace Donatella.App.Concrete
{
    public class EnderecoApp : IEnderecoApp
    {
        private readonly IRepository<Endereco> _enderecoRepository;

        public EnderecoApp(IRepository<Endereco> enderecoRepository)
        {
            _enderecoRepository = enderecoRepository;
        }

        public Endereco Endereco(int id)
        {
            return _enderecoRepository.Get(id);
        }

        public Endereco Salvar(Endereco endereco)
        {
            var enderecoDb = _enderecoRepository.Get().FirstOrDefault(x => x.Id == endereco.Id) ?? endereco;

            enderecoDb.Bairro = endereco.Bairro;
            enderecoDb.Logradouro = endereco.Logradouro;
            enderecoDb.Numero = endereco.Numero;
            enderecoDb.Uf = endereco.Uf;
            enderecoDb.Cep = TextoHelpers.GetNumeros(endereco.Cep);
            enderecoDb.Cidade = endereco.Cidade;
            enderecoDb.Complemento = endereco.Complemento;

            _enderecoRepository.AddOrUpdate(enderecoDb);
            _enderecoRepository.Commit();

            return enderecoDb;
        }
    }
}