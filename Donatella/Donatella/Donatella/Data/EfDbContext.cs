using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls.Expressions;
using Donatella.Data.Entities;

namespace Donatella.Data
{
    public class EfDbContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<FaleConosco> FaleConoscos { get; set; }
        public DbSet<Faq> Faqs { get; set; }
        public DbSet<FaqGrupo> FaqGrupos { get; set; }
        public DbSet<PerfilAcesso> PerfilAcessos { get; set; }
        public DbSet<PerfilAcessoPermissao> PerfilAcessoPermissao { get; set; }
        public DbSet<Log> Log { get; set; }
        public DbSet<Mensagem> Mensagens { get; set; }
        public DbSet<Estado> Estados { get; set; }
        public DbSet<Cargo> Cargos { get; set; }
        public DbSet<Carrinho> Carrinhos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<FormaDePagamento> FormasDePagamento { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<PedidoProduto> PedidosProdutos { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<StatusPedido> StatusPedidos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }
    }
}