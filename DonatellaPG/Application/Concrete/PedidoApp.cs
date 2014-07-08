using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;


namespace Application.Concrete
{
    public class PedidoApp : AppBase, IPedidoApp
    {
        private IRepositoryBase<Pedido> _pedidoRepository;
        public PedidoApp(IRepositoryBase<Pedido> pedidoRepository)
        {
            _pedidoRepository = pedidoRepository;
        }
        public IEnumerable<Pedido> Pedidos
        {
            get { return _pedidoRepository.Get(); }
        }

        public void SalvarPedido(Pedido pedido)
        {
            BeginTransaction();

            var dbPedido = pedido.PedidoId == 0 ? new Pedido() { Data = DateTime.Now }
                : _pedidoRepository.Get(pedido.PedidoId);

            if (dbPedido == null)
                throw new Exception("Pedido não pode ser alterado, pois não existe no banco.");

            dbPedido.Cliente = pedido.Cliente;
            dbPedido.Mesa = pedido.Mesa;
            dbPedido.NotaAvaliacao = pedido.NotaAvaliacao;
            dbPedido.Status = pedido.Status;
            dbPedido.ValorTotal = pedido.ValorTotal;

            if (dbPedido.PedidoId == 0)
                _pedidoRepository.Add(dbPedido);

            Commint();
        }
    }
}
