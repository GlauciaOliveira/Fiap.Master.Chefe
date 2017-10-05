using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fiap.Master.Chefe.Core.Model;

namespace Fiap.Master.Chefe.Core.Repository
{
    public class MasterChefeContext : DbContext 
    {

        public MasterChefeContext() : base(new DbContextOptionsBuilder<MasterChefeContext>()
            .UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=DbMasterChefe;
                            Trusted_Connection=True;MultipleActiveResultSets=true").Options)
        {

        }

        public DbSet<Model.Receitas> Receita { get; set; }
        public DbSet<Model.Ingredientes> Ingrediente { get; set; }
        public DbSet<Model.ReceitaIngredientes> ReceitaIngredientes { get; set; }
        public DbSet<Model.Usuarios> Usuario { get; set; }
        public DbSet<Model.Categorias> Categoria { get; set; }
        public DbSet<Model.Comentarios> Comentario { get; set; }
        public DbSet<Model.ReceitaPontuacao> ReceitaPontuacao { get; set; }
        //public DbSet<Model.Pontuacao> Pontuacao { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ReceitaIngredientes>()
                .HasKey(x => new { x.ReceitasId, x.IngredientesId });

            //modelBuilder.Entity<ReceitaPontuacao>()
            //    .HasKey(x => new { x.ReceitasId, x.PontuacaoId });

            modelBuilder.Entity<ReceitaIngredientes>()
                .HasOne(x => x.Receita)
                .WithMany(y => y.ReceitaIngredientes)
                .HasForeignKey(y => y.ReceitasId);

            modelBuilder.Entity<ReceitaIngredientes>()
                .HasOne(x => x.Ingrediente)
                .WithMany(y => y.ReceitaIngredientes)
                .HasForeignKey(y => y.IngredientesId);

            //modelBuilder.Entity<ReceitaPontuacao>()
            //    .HasOne(x => x.Receita)
            //    .WithMany(y => y.ReceitaPontuacao)
            //    .HasForeignKey(y => y.ReceitasId);

            //modelBuilder.Entity<ReceitaPontuacao>()
            //    .HasOne(x => x.Pontuacao)
            //    .WithMany(y => y.ReceitaPontuacao)
            //    .HasForeignKey(y => y.PontuacaoId);

            //modelBuilder.Entity<Usuarios>()
            //    .HasMany(c => c.Comentarios)
            //    .WithOne(e => e.Usuario);

            modelBuilder.Entity<Categorias>()
                .HasMany(c => c.Receitas)
                .WithOne(e => e.Categoria);
        }

    }


}
