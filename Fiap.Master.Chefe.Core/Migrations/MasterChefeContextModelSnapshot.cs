using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Fiap.Master.Chefe.Core.Repository;

namespace Fiap.Master.Chefe.Core.Migrations
{
    [DbContext(typeof(MasterChefeContext))]
    partial class MasterChefeContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Fiap.Master.Chefe.Core.Model.Ingrediente", b =>
                {
                    b.Property<int>("IngredienteId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Nome");

                    b.Property<string>("Observacao");

                    b.HasKey("IngredienteId");

                    b.ToTable("Ingrediente");
                });

            modelBuilder.Entity("Fiap.Master.Chefe.Core.Model.Receita", b =>
                {
                    b.Property<int>("ReceitaId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DataCadastro");

                    b.Property<string>("Titulo");

                    b.Property<int?>("UsuarioId");

                    b.HasKey("ReceitaId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Receita");
                });

            modelBuilder.Entity("Fiap.Master.Chefe.Core.Model.ReceitaIngredientes", b =>
                {
                    b.Property<int>("ReceitaId");

                    b.Property<int>("IngredienteId");

                    b.HasKey("ReceitaId", "IngredienteId");

                    b.HasIndex("IngredienteId");

                    b.ToTable("ReceitaIngredientes");
                });

            modelBuilder.Entity("Fiap.Master.Chefe.Core.Model.Usuario", b =>
                {
                    b.Property<int>("UsuarioId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Login");

                    b.Property<string>("Nome");

                    b.Property<string>("Password");

                    b.HasKey("UsuarioId");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("Fiap.Master.Chefe.Core.Model.Receita", b =>
                {
                    b.HasOne("Fiap.Master.Chefe.Core.Model.Usuario", "Usuario")
                        .WithMany("Receitas")
                        .HasForeignKey("UsuarioId");
                });

            modelBuilder.Entity("Fiap.Master.Chefe.Core.Model.ReceitaIngredientes", b =>
                {
                    b.HasOne("Fiap.Master.Chefe.Core.Model.Ingrediente", "Ingrediente")
                        .WithMany("ReceitaIngredientes")
                        .HasForeignKey("IngredienteId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Fiap.Master.Chefe.Core.Model.Receita", "Receita")
                        .WithMany("ReceitaIngredientes")
                        .HasForeignKey("ReceitaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
