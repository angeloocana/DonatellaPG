using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Donatella.Models;
using Donatella.Models.Cargos;
using Donatella.Models.Enums;
using Donatella.Data.Entities;

namespace Donatella.App.Interface
{
    public interface ICargoApp
    {
        Dictionary<int, string> Combo();
        Cargo FindByNome(string nome);
        void Salvar(CargoViewModel cargo);
        void Excluir(int cargoId);
        CargoViewModel Cargo(int id);
        IEnumerable<Cargo> Cargos();
    }
}