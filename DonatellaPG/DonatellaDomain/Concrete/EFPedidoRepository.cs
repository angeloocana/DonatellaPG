using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DonatellaDomain.Abstract;
using DonatellaDomain.Entities;

namespace DonatellaDomain.Concrete
{
    public class EFPedidoRepository : IPedidoRepository
    {
        private EFDbContext _dbContext;
        public EFPedidoRepository()
        {
            _dbContext = new EFDbContext();
        }
        public IQueryable<Pedido> Pedidos
        {
            get { return _dbContext.Pedidos; }
        }

        public void SalvarPedido(Pedido pedido)
        {
            var dbPedido = pedido.PedidoId == 0 ? new Pedido() { Data = DateTime.Now }
                : _dbContext.Pedidos.Find(pedido.PedidoId);

            if (dbPedido == null)
                throw new Exception("Pedido não pode ser alterado, pois não existe no banco.");

            dbPedido.Cliente = pedido.Cliente;
            dbPedido.Mesa = pedido.Mesa;
            dbPedido.NotaAvaliacao = pedido.NotaAvaliacao;
            dbPedido.Status = pedido.Status;
            dbPedido.ValorTotal = pedido.ValorTotal;

            if (dbPedido.PedidoId == 0)
                _dbContext.Pedidos.Add(dbPedido);

            _dbContext.SaveChanges();
        }
    }
}
