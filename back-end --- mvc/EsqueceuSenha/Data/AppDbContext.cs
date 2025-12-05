using System;
using System.Collections.Generic;
using EsqueceuSenha.Models;
using Microsoft.EntityFrameworkCore;

namespace EsqueceuSenha.Data;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Comentario> Comentarios { get; set; }

    public virtual DbSet<Filme> Filmes { get; set; }

    public virtual DbSet<RegraPerfil> RegraPerfils { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<codigoUsuarioSenha> codigoUsuarioSenhas { get; set; }

    public virtual DbSet<diretorFilme> diretorFilmes { get; set; }

    public virtual DbSet<generoFilme> generoFilmes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:ConexaoPadrao");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Comentario>(entity =>
        {
            entity.HasKey(e => e.id_comentario).HasName("PK__Comentar__1BA6C6F4FC3F6FF9");

            entity.ToTable("Comentario");

            entity.Property(e => e.data_postagem).HasColumnType("datetime");
            entity.Property(e => e.tipo_comentario)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.id_filmeNavigation).WithMany(p => p.Comentarios)
                .HasForeignKey(d => d.id_filme)
                .HasConstraintName("fk_idFilme_Comentario");

            entity.HasOne(d => d.id_usuarioNavigation).WithMany(p => p.Comentarios)
                .HasForeignKey(d => d.id_usuario)
                .HasConstraintName("FK__Comentari__id_us__5812160E");
        });

        modelBuilder.Entity<Filme>(entity =>
        {
            entity.HasKey(e => e.id_filme).HasName("PK__Filme__44A1920DBD7765C8");

            entity.ToTable("Filme");

            entity.Property(e => e.descricao_filme)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.nome)
                .HasMaxLength(40)
                .IsUnicode(false);

            entity.HasOne(d => d.id_diretorNavigation).WithMany(p => p.Filmes)
                .HasForeignKey(d => d.id_diretor)
                .HasConstraintName("fk_idDiretor_filme");

            entity.HasOne(d => d.id_generoNavigation).WithMany(p => p.Filmes)
                .HasForeignKey(d => d.id_genero)
                .HasConstraintName("fk_idGenero_filme");
        });

        modelBuilder.Entity<RegraPerfil>(entity =>
        {
            entity.HasKey(e => e.IdRegra).HasName("PK__RegraPer__E4F2CC24923D6A48");

            entity.ToTable("RegraPerfil");

            entity.HasIndex(e => e.Nome, "UQ__RegraPer__7D8FE3B2DD15871E").IsUnique();

            entity.Property(e => e.Nome).HasMaxLength(40);
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.id_usuario).HasName("PK__Usuario__4E3E04ADF12CC7D5");

            entity.ToTable("Usuario");

            entity.HasIndex(e => e.email, "UQ__Usuario__AB6E6164C11082B3").IsUnique();

            entity.Property(e => e.desc_perfil).HasMaxLength(100);
            entity.Property(e => e.email)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.nick_name)
                .HasMaxLength(12)
                .IsUnicode(false);
            entity.Property(e => e.nome)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.senha).HasMaxLength(32);

            entity.HasOne(d => d.Regra).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.RegraId)
                .HasConstraintName("FK_Usuario_Regra");
        });

        modelBuilder.Entity<codigoUsuarioSenha>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK__codigoUs__3213E83F7869EAB1");

            entity.ToTable("codigoUsuarioSenha");

            entity.HasOne(d => d.idUsuarioNavigation).WithMany(p => p.codigoUsuarioSenhas)
                .HasForeignKey(d => d.idUsuario)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_userId_codigoUsuarioSenha");
        });

        modelBuilder.Entity<diretorFilme>(entity =>
        {
            entity.HasKey(e => e.id_diretor).HasName("PK__diretorF__A745748EE7340AD3");

            entity.ToTable("diretorFilme");

            entity.Property(e => e.nome)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<generoFilme>(entity =>
        {
            entity.HasKey(e => e.id_genero).HasName("PK__generoFi__99A8E4F90DEAD35F");

            entity.ToTable("generoFilme");

            entity.Property(e => e.nome_genero)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
