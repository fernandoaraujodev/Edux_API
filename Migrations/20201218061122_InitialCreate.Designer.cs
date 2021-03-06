﻿// <auto-generated />
using System;
using Edux.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Edux.Migrations
{
    [DbContext(typeof(EduxContext))]
    [Migration("20201218061122_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Edux.Domains.AlunoObjetivo", b =>
                {
                    b.Property<int>("IdAlunoObjetivo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("DataAlcancada")
                        .HasColumnType("datetime");

                    b.Property<int>("IdAlunoTurma")
                        .HasColumnType("int");

                    b.Property<int>("IdObjetivo")
                        .HasColumnType("int");

                    b.Property<decimal?>("Nota")
                        .HasColumnType("decimal(18, 0)");

                    b.HasKey("IdAlunoObjetivo")
                        .HasName("PK__AlunoObj__DE5E755D582F8C90");

                    b.HasIndex("IdAlunoTurma");

                    b.HasIndex("IdObjetivo");

                    b.ToTable("AlunoObjetivo");
                });

            modelBuilder.Entity("Edux.Domains.AlunoTurma", b =>
                {
                    b.Property<int>("IdAlunoTurma")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdTurma")
                        .HasColumnType("int");

                    b.Property<int>("IdUsuario")
                        .HasColumnType("int");

                    b.Property<string>("Matricula")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.HasKey("IdAlunoTurma")
                        .HasName("PK__AlunoTur__8F3223BD18815873");

                    b.HasIndex("IdTurma");

                    b.HasIndex("IdUsuario");

                    b.ToTable("AlunoTurma");
                });

            modelBuilder.Entity("Edux.Domains.Categoria", b =>
                {
                    b.Property<int>("IdCategoria")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.HasKey("IdCategoria")
                        .HasName("PK__Categori__A3C02A104A7A6D0D");

                    b.ToTable("Categoria");
                });

            modelBuilder.Entity("Edux.Domains.Curso", b =>
                {
                    b.Property<int>("IdCurso")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdInstituicao")
                        .HasColumnType("int");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.HasKey("IdCurso")
                        .HasName("PK__Curso__085F27D6A3EC56A1");

                    b.HasIndex("IdInstituicao");

                    b.ToTable("Curso");
                });

            modelBuilder.Entity("Edux.Domains.Curtida", b =>
                {
                    b.Property<int>("IdCurtida")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdDica")
                        .HasColumnType("int");

                    b.Property<int>("IdUsuario")
                        .HasColumnType("int");

                    b.HasKey("IdCurtida")
                        .HasName("PK__Curtida__2169583A08713BC2");

                    b.HasIndex("IdDica");

                    b.HasIndex("IdUsuario");

                    b.ToTable("Curtida");
                });

            modelBuilder.Entity("Edux.Domains.Dica", b =>
                {
                    b.Property<int>("IdDica")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdUsuario")
                        .HasColumnType("int");

                    b.Property<string>("Imagem")
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.Property<string>("Texto")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.HasKey("IdDica")
                        .HasName("PK__Dica__F1688516DC46EA12");

                    b.HasIndex("IdUsuario");

                    b.ToTable("Dica");
                });

            modelBuilder.Entity("Edux.Domains.Instituicao", b =>
                {
                    b.Property<int>("IdInstituicao")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.Property<string>("Cep")
                        .IsRequired()
                        .HasColumnName("CEP")
                        .HasColumnType("varchar(15)")
                        .HasMaxLength(15)
                        .IsUnicode(false);

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.Property<string>("Complemento")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.Property<string>("Logradouro")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.Property<string>("Uf")
                        .IsRequired()
                        .HasColumnName("UF")
                        .HasColumnType("char(2)")
                        .IsFixedLength(true)
                        .HasMaxLength(2)
                        .IsUnicode(false);

                    b.HasKey("IdInstituicao")
                        .HasName("PK__Institui__B771C0D80244B8AE");

                    b.ToTable("Instituicao");
                });

            modelBuilder.Entity("Edux.Domains.Objetivo", b =>
                {
                    b.Property<int>("IdObjetivo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.Property<int>("IdCategoria")
                        .HasColumnType("int");

                    b.HasKey("IdObjetivo")
                        .HasName("PK__Objetivo__E210F071241BBD58");

                    b.HasIndex("IdCategoria");

                    b.ToTable("Objetivo");
                });

            modelBuilder.Entity("Edux.Domains.Perfil", b =>
                {
                    b.Property<int>("IdPerfil")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Permissao")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.HasKey("IdPerfil")
                        .HasName("PK__Perfil__C7BD5CC18D4885D9");

                    b.ToTable("Perfil");
                });

            modelBuilder.Entity("Edux.Domains.ProfessorTurma", b =>
                {
                    b.Property<int>("IdProfessorTurma")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.Property<int>("IdTurma")
                        .HasColumnType("int");

                    b.Property<int>("IdUsuario")
                        .HasColumnType("int");

                    b.HasKey("IdProfessorTurma")
                        .HasName("PK__Professo__D4E74F9EF71AF7D9");

                    b.HasIndex("IdTurma");

                    b.HasIndex("IdUsuario");

                    b.ToTable("ProfessorTurma");
                });

            modelBuilder.Entity("Edux.Domains.Turma", b =>
                {
                    b.Property<int>("IdTurma")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.Property<int>("IdCurso")
                        .HasColumnType("int");

                    b.HasKey("IdTurma")
                        .HasName("PK__Turma__C1ECFFC97B42BF2E");

                    b.HasIndex("IdCurso");

                    b.ToTable("Turma");
                });

            modelBuilder.Entity("Edux.Domains.Usuario", b =>
                {
                    b.Property<int>("IdUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("DataCadastro")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("DataUltimoAcesso")
                        .HasColumnType("datetime");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.Property<int>("IdPerfil")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.HasKey("IdUsuario")
                        .HasName("PK__Usuario__5B65BF9713B66C86");

                    b.HasIndex("IdPerfil");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("Edux.Domains.AlunoObjetivo", b =>
                {
                    b.HasOne("Edux.Domains.AlunoTurma", "IdAlunoTurmaNavigation")
                        .WithMany("AlunoObjetivo")
                        .HasForeignKey("IdAlunoTurma")
                        .HasConstraintName("FK__AlunoObje__IdAlu__571DF1D5")
                        .IsRequired();

                    b.HasOne("Edux.Domains.Objetivo", "IdObjetivoNavigation")
                        .WithMany("AlunoObjetivo")
                        .HasForeignKey("IdObjetivo")
                        .HasConstraintName("FK__AlunoObje__IdObj__5812160E")
                        .IsRequired();
                });

            modelBuilder.Entity("Edux.Domains.AlunoTurma", b =>
                {
                    b.HasOne("Edux.Domains.Turma", "IdTurmaNavigation")
                        .WithMany("AlunoTurma")
                        .HasForeignKey("IdTurma")
                        .HasConstraintName("FK__AlunoTurm__IdTur__5070F446")
                        .IsRequired();

                    b.HasOne("Edux.Domains.Usuario", "IdUsuarioNavigation")
                        .WithMany("AlunoTurma")
                        .HasForeignKey("IdUsuario")
                        .HasConstraintName("FK__AlunoTurm__IdUsu__4F7CD00D")
                        .IsRequired();
                });

            modelBuilder.Entity("Edux.Domains.Curso", b =>
                {
                    b.HasOne("Edux.Domains.Instituicao", "IdInstituicaoNavigation")
                        .WithMany("Curso")
                        .HasForeignKey("IdInstituicao")
                        .HasConstraintName("FK__Curso__IdInstitu__3C69FB99")
                        .IsRequired();
                });

            modelBuilder.Entity("Edux.Domains.Curtida", b =>
                {
                    b.HasOne("Edux.Domains.Dica", "IdDicaNavigation")
                        .WithMany("Curtida")
                        .HasForeignKey("IdDica")
                        .HasConstraintName("FK__Curtida__IdDica__4CA06362")
                        .IsRequired();

                    b.HasOne("Edux.Domains.Usuario", "IdUsuarioNavigation")
                        .WithMany("Curtida")
                        .HasForeignKey("IdUsuario")
                        .HasConstraintName("FK__Curtida__IdUsuar__4BAC3F29")
                        .IsRequired();
                });

            modelBuilder.Entity("Edux.Domains.Dica", b =>
                {
                    b.HasOne("Edux.Domains.Usuario", "IdUsuarioNavigation")
                        .WithMany("Dica")
                        .HasForeignKey("IdUsuario")
                        .HasConstraintName("FK__Dica__IdUsuario__48CFD27E")
                        .IsRequired();
                });

            modelBuilder.Entity("Edux.Domains.Objetivo", b =>
                {
                    b.HasOne("Edux.Domains.Categoria", "IdCategoriaNavigation")
                        .WithMany("Objetivo")
                        .HasForeignKey("IdCategoria")
                        .HasConstraintName("FK__Objetivo__IdCate__534D60F1")
                        .IsRequired();
                });

            modelBuilder.Entity("Edux.Domains.ProfessorTurma", b =>
                {
                    b.HasOne("Edux.Domains.Turma", "IdTurmaNavigation")
                        .WithMany("ProfessorTurma")
                        .HasForeignKey("IdTurma")
                        .HasConstraintName("FK__Professor__IdTur__45F365D3")
                        .IsRequired();

                    b.HasOne("Edux.Domains.Usuario", "IdUsuarioNavigation")
                        .WithMany("ProfessorTurma")
                        .HasForeignKey("IdUsuario")
                        .HasConstraintName("FK__Professor__IdUsu__44FF419A")
                        .IsRequired();
                });

            modelBuilder.Entity("Edux.Domains.Turma", b =>
                {
                    b.HasOne("Edux.Domains.Curso", "IdCursoNavigation")
                        .WithMany("Turma")
                        .HasForeignKey("IdCurso")
                        .HasConstraintName("FK__Turma__IdCurso__3F466844")
                        .IsRequired();
                });

            modelBuilder.Entity("Edux.Domains.Usuario", b =>
                {
                    b.HasOne("Edux.Domains.Perfil", "IdPerfilNavigation")
                        .WithMany("Usuario")
                        .HasForeignKey("IdPerfil")
                        .HasConstraintName("FK__Usuario__IdPerfi__4222D4EF")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
