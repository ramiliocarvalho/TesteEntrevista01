﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using WebAppTesteEntrevista01.Models;

#nullable disable

namespace WebAppTesteEntrevista01.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20240304154009_Criando relacionamento Usuario Entregador")]
    partial class CriandorelacionamentoUsuarioEntregador
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("WebAppTesteEntrevista01.Models.Entregador", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Cnpj")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("EnderecoImagemCnh")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("NumeroCnh")
                        .HasColumnType("integer");

                    b.Property<int>("TipoCnh")
                        .HasColumnType("integer");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Entregadores");
                });

            modelBuilder.Entity("WebAppTesteEntrevista01.Models.Locacao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DataInicio")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DataPrevisaoTerminoSistema")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("DataPrevisaoTerminoUsuario")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DataTermino")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("EntregadorId")
                        .HasColumnType("integer");

                    b.Property<int>("MotoId")
                        .HasColumnType("integer");

                    b.Property<int>("PlanoId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Locacoes");
                });

            modelBuilder.Entity("WebAppTesteEntrevista01.Models.Moto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Ano")
                        .HasColumnType("integer");

                    b.Property<string>("Modelo")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Placa")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Motos");
                });

            modelBuilder.Entity("WebAppTesteEntrevista01.Models.NotificacaoPedido", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DataNotificacao")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("EntregadorId")
                        .HasColumnType("integer");

                    b.Property<int>("PedidoId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("NotificacoesPedidos");
                });

            modelBuilder.Entity("WebAppTesteEntrevista01.Models.Pedido", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("DataAceite")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DataCricao")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("DataEntrega")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("EntregadorId")
                        .HasColumnType("integer");

                    b.Property<int>("SituacaoId")
                        .HasColumnType("integer");

                    b.Property<decimal>("ValorCorrida")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.ToTable("Pedidos");
                });

            modelBuilder.Entity("WebAppTesteEntrevista01.Models.Plano", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("NumeroDias")
                        .HasColumnType("integer");

                    b.Property<int>("PorcentagemDiariaNaoEfetivada")
                        .HasColumnType("integer");

                    b.Property<decimal>("ValorDia")
                        .HasColumnType("numeric");

                    b.Property<decimal>("ValorDiariaAdicional")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.ToTable("Planos");
                });

            modelBuilder.Entity("WebAppTesteEntrevista01.Models.Situacao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Situacoes");
                });

            modelBuilder.Entity("WebAppTesteEntrevista01.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("DataAlteracao")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Perfil")
                        .HasColumnType("integer");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("WebAppTesteEntrevista01.Models.Entregador", b =>
                {
                    b.HasOne("WebAppTesteEntrevista01.Models.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });
#pragma warning restore 612, 618
        }
    }
}