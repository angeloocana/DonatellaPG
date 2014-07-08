using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Ninject;
using Application.Interfaces;
using Application.Concrete;
using Domain.Interfaces;
using Domain;

namespace DonatellaAdmin.infrastructure
{
    public class NinjectControllerFactory : DefaultControllerFactory
    {
        private IKernel ninjectKernel;
        public NinjectControllerFactory()
        {
            ninjectKernel = new StandardKernel();
            AddBindings();
        }

        protected override IController GetControllerInstance(RequestContext
        requestContext, Type controllerType)
        {
            return controllerType == null
            ? null
            : (IController)ninjectKernel.Get(controllerType);
        }

        private void AddBindings()
        {
            ninjectKernel.Bind<ICargoApp>().To<CargoApp>();
            ninjectKernel.Bind<ICategoriaApp>().To<CategoriaApp>();
            ninjectKernel.Bind<IEstoqueApp>().To<EstoqueApp>();
            ninjectKernel.Bind<IFormaDePagamentoApp>().To<FormaDePagamentoApp>();
            ninjectKernel.Bind<IFornecedorApp>().To<FornecedorApp>();
            ninjectKernel.Bind<IFuncionarioApp>().To<FuncionarioApp>();
            ninjectKernel.Bind<IIngredienteApp>().To<IngredienteApp>();
            ninjectKernel.Bind<IPedidoApp>().To<PedidoApp>();
            ninjectKernel.Bind<IProdutoApp>().To<ProdutoApp>();
            //ninjectKernel.Bind(typeof(IRepositoryBase<>)).To<IRepositoryBase>();
        }
    }
}