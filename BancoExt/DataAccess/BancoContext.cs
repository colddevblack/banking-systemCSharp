using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using BancoExt.Models;
using System.Runtime.Remoting.Contexts;
using System.Data.SqlClient;


namespace BancoExt.DataAccess
{
    public class BancoContext : DbContext
    {
        public BancoContext() : base("ConnectionBank") { }
        public virtual DbSet<ClienteModel> clientedb { get; set; }
        public virtual DbSet<ContaModel> contadb { get; set; }
        public virtual DbSet<TipoContaModel> tipocontadb { get; set; }
        public virtual DbSet<TipoTransacaoModel> tipotransacaodb { get; set; }
        public virtual DbSet<TransacaoModel> transacaodb { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClienteModel>()
                .HasMany(e => e.contas)
                .WithRequired(e => e.ClienteModel)
                .HasForeignKey(e => e.clienteid)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<TipoContaModel>()
                ;
            modelBuilder.Entity<ContaModel>()
                .HasMany(e => e.transacao)
                .WithRequired(e => e.ContaModel)
                .HasForeignKey(e => e.contaid)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TipoTransacaoModel>()
                    .HasMany(e => e.transacao)
                    .WithRequired(e => e.TipoTransacaoModel)
                    .HasForeignKey(e => e.tipotransacaoid)
                    .WillCascadeOnDelete(false);
        }
    }

}