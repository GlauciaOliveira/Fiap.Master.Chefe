﻿// <auto-generated />
using Fiap.Master.Chefe.Core.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace Fiap.Master.Chefe.Core.Migrations
{
    [DbContext(typeof(MasterChefeContext))]
    partial class MasterChefeContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Fiap.Master.Chefe.Core.Model.Categorias", b =>
                {
                    b.Property<int>("CategoriasId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Descricao");

                    b.HasKey("CategoriasId");

                    b.ToTable("Categoria");
                });

            modelBuilder.Entity("Fiap.Master.Chefe.Core.Model.Comentarios", b =>
                {
                    b.Property<int>("ComentariosId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DataInclusao");

                    b.Property<int?>("ReceitasId");

                    b.Property<string>("Texto");

                    b.Property<int?>("UsuariosId");

                    b.HasKey("ComentariosId");

                    b.HasIndex("ReceitasId");

                    b.HasIndex("UsuariosId");

                    b.ToTable("Comentario");
                });

            modelBuilder.Entity("Fiap.Master.Chefe.Core.Model.Ingredientes", b =>
                {
                    b.Property<int>("IngredientesId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Nome");

                    b.Property<string>("Observacao");

                    b.HasKey("IngredientesId");

                    b.ToTable("Ingrediente");
                });

            modelBuilder.Entity("Fiap.Master.Chefe.Core.Model.Pontuacao", b =>
                {
                    b.Property<int>("PontuacaoId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Nota");

                    b.HasKey("PontuacaoId");

                    b.ToTable("Pontuacao");
                });

            modelBuilder.Entity("Fiap.Master.Chefe.Core.Model.ReceitaIngredientes", b =>
                {
                    b.Property<int>("ReceitasId");

                    b.Property<int>("IngredientesId");

                    b.HasKey("ReceitasId", "IngredientesId");

                    b.HasIndex("IngredientesId");

                    b.ToTable("ReceitaIngredientes");
                });

            modelBuilder.Entity("Fiap.Master.Chefe.Core.Model.ReceitaPontuacao", b =>
                {
                    b.Property<int>("ReceitasId");

                    b.Property<int>("PontuacaoId");

                    b.HasKey("ReceitasId", "PontuacaoId");

                    b.HasIndex("PontuacaoId");

                    b.ToTable("ReceitaPontuacao");
                });

            modelBuilder.Entity("Fiap.Master.Chefe.Core.Model.Receitas", b =>
                {
                    b.Property<int>("ReceitasId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CategoriasId");

                    b.Property<DateTime>("DataCadastro");

                    b.Property<string>("ModoPreparo");

                    b.Property<string>("Titulo");

                    b.Property<int?>("UsuariosId");

                    b.HasKey("ReceitasId");

                    b.HasIndex("CategoriasId");

                    b.HasIndex("UsuariosId");

                    b.ToTable("Receita");
                });

            modelBuilder.Entity("Fiap.Master.Chefe.Core.Model.Usuarios", b =>
                {
                    b.Property<int>("UsuariosId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Login");

                    b.Property<string>("Nome");

                    b.Property<string>("Password");

                    b.HasKey("UsuariosId");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("Fiap.Master.Chefe.Core.Model.Comentarios", b =>
                {
                    b.HasOne("Fiap.Master.Chefe.Core.Model.Receitas")
                        .WithMany("Comentarios")
                        .HasForeignKey("ReceitasId");

                    b.HasOne("Fiap.Master.Chefe.Core.Model.Usuarios", "Usuario")
                        .WithMany("Comentarios")
                        .HasForeignKey("UsuariosId");
                });

            modelBuilder.Entity("Fiap.Master.Chefe.Core.Model.ReceitaIngredientes", b =>
                {
                    b.HasOne("Fiap.Master.Chefe.Core.Model.Ingredientes", "Ingrediente")
                        .WithMany("ReceitaIngredientes")
                        .HasForeignKey("IngredientesId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Fiap.Master.Chefe.Core.Model.Receitas", "Receita")
                        .WithMany("ReceitaIngredientes")
                        .HasForeignKey("ReceitasId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Fiap.Master.Chefe.Core.Model.ReceitaPontuacao", b =>
                {
                    b.HasOne("Fiap.Master.Chefe.Core.Model.Pontuacao", "Pontuacao")
                        .WithMany("ReceitaPontuacao")
                        .HasForeignKey("PontuacaoId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Fiap.Master.Chefe.Core.Model.Receitas", "Receita")
                        .WithMany("ReceitaPontuacao")
                        .HasForeignKey("ReceitasId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Fiap.Master.Chefe.Core.Model.Receitas", b =>
                {
                    b.HasOne("Fiap.Master.Chefe.Core.Model.Categorias", "Categoria")
                        .WithMany("Receitas")
                        .HasForeignKey("CategoriasId");

                    b.HasOne("Fiap.Master.Chefe.Core.Model.Usuarios", "Usuario")
                        .WithMany("Receitas")
                        .HasForeignKey("UsuariosId");
                });
#pragma warning restore 612, 618
        }
    }
}
