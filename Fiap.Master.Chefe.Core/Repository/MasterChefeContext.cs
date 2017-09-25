using Fiap.Master.Chefe.Core.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fiap.Master.Chefe.Core.Repository
{
    public partial class MasterChefeContext : DbContext
    {
        public MasterChefeContext() : base(new DbContextOptionsBuilder<MasterChefeContext>()
            .UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=DbMasterChefe;
                            Trusted_Connection=True;MultipleActiveResultSets=true").Options)
        {

        }

        public DbSet<Model.Receita> Receita { get; set; }
        public DbSet<Model.Ingrediente> Ingrediente { get; set; }
        public DbSet<Model.ReceitaIngredientes> ReceitaIngredientes { get; set; }
        public DbSet<Model.Usuario> Usuario { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ReceitaIngredientes>()
                .HasKey(x => new { x.ReceitaId, x.IngredienteId});

            modelBuilder.Entity<ReceitaIngredientes>()
                .HasOne(x => x.Receita)
                .WithMany(y => y.ReceitaIngredientes)
                .HasForeignKey(y => y.ReceitaId);

            modelBuilder.Entity<ReceitaIngredientes>()
                .HasOne(x => x.Ingrediente)
                .WithMany(y => y.ReceitaIngredientes)
                .HasForeignKey(y => y.IngredienteId);
        }
    }
}
