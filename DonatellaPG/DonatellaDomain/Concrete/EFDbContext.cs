using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using DonatellaDomain.Entities;

namespace DonatellaDomain.Concrete
{
    public class EFDbContext : DbContext
    {
        public DbSet<Cargo> Cargos { get; set; }
        public DbSet<Carrinho> Carrinhos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Estoque> Estoques { get; set; }
        public DbSet<FormaDePagamento> FormasDePagamento { get; set; }
        public DbSet<Fornecedor> Fornecedores { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<FuncionarioPermissao> FuncionariosPermissoes { get; set; }
        public DbSet<Ingrediente> Ingredientes { get; set; }
        public DbSet<IngredienteFornecedor> IngredientesFornecedores { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<PedidoProduto> PedidosProdutos { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<ProdutoIngrediente> ProdutosIngredientes { get; set; }
        public DbSet<StatusPedido> StatusPedidos { get; set; }

    }
}
