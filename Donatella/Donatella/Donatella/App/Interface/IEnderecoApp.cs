using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Donatella.Data.Entities;

namespace Donatella.App.Interface
{
    public interface IEnderecoApp
    {
        Endereco Endereco(int id);
        Endereco Salvar(Endereco endereco);
    }
}