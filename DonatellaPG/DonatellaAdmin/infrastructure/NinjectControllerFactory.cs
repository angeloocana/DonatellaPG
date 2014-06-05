using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Ninject;
using DonatellaDomain.Abstract;
using DonatellaDomain.Concrete;

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
            ninjectKernel.Bind<ICargoRepository>().To<EFCargoRepository>();
            ninjectKernel.Bind<ICategoriaRepository>().To<EFCategoriaRepository>();
            ninjectKernel.Bind<IEstoqueRepository>().To<EFEstoqueRepository>();
            ninjectKernel.Bind<IFormaDePagamentoRepository>().To<EFFormaDePagamentoRepository>();
            ninjectKernel.Bind<IFornecedorRepository>().To<EFFornecedorRepository>();
            ninjectKernel.Bind<IFuncionarioRepository>().To<EFFuncionarioRepository>();
            ninjectKernel.Bind<IIngredienteRepository>().To<EFIngredienteRepository>();
            ninjectKernel.Bind<IPedidoRepository>().To<EFPedidoRepository>();
            ninjectKernel.Bind<IProdutoRepository>().To<EFProdutoRepository>();
        }
    }
}