using Microsoft.EntityFrameworkCore;
using Proj.Manager.Core.Entities;

namespace Proj.Manager.Infrastructure.Persistence.SQLServer
{
    public class SqlServerDBContext : DbContext
    {
        public SqlServerDBContext(DbContextOptions<SqlServerDBContext> options) : base(options)
        { }

        public DbSet<Projeto> Projeto { get; set; }
        public DbSet<Membro> Membro { get; set; }
        public DbSet<Tarefa> Tarefa { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ProjetoBuilder(modelBuilder);
            MembroBuilder(modelBuilder);
            TarefasBuilder(modelBuilder);
        }

        public void ProjetoBuilder(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Projeto>(e =>
            {
                e.ToTable(Table.Projeto);

                e.HasKey(x => x.Id);

                e.Property(x => x.GerenteId)
                    .HasColumnName("GerenteId")
                    .IsRequired();

                e.Property(x => x.Nome)
                    .HasColumnName("Name")
                    .HasColumnType("varchar(50)")
                    .HasMaxLength(50)
                    .IsRequired();

                e.Property(x => x.Descricao)
                    .HasColumnName("Descricao")
                    .HasColumnType("varchar(255)")
                    .HasMaxLength(255)
                    .IsRequired();

                e.Property(x => x.DataInicio)
                    .HasColumnName("DataInicio")
                    .HasColumnType("datetime")
                    .IsRequired();

                e.Property(x => x.DataPrazo)
                   .HasColumnName("DataPrazo")
                   .HasColumnType("datetime")
                   .IsRequired();

                e.Property(x => x.DataTermino)
                   .HasColumnName("DataTermino")
                   .HasColumnType("datetime")
                   .IsRequired(false);

                e.Property(x => x.Status)
                   .HasColumnName("Status")
                   .HasColumnType("int");

                e.HasMany(x => x.Tarefas)
                    .WithOne()
                    .HasForeignKey(x => x.ProjetoId);

                e.HasOne(x => x.Gerente)
                    .WithMany(x => x.Projetos)
                    .HasForeignKey(x => x.GerenteId)
                    .OnDelete(DeleteBehavior.NoAction);
            });
        }
        public void MembroBuilder(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Membro>(e =>
            {
                e.ToTable(Table.Membro);

                e.HasKey(x => x.Id);

                e.Property(x => x.Nome)
                    .HasColumnName("Nome")
                    .HasColumnType("varchar(50)")
                    .HasMaxLength(50)
                    .IsRequired();

                e.Property(x => x.Email)
                    .HasColumnName("Email")
                    .HasColumnType("varchar(255)")
                    .HasMaxLength(255)
                    .IsRequired();

                e.Property(x => x.Senha)
                    .HasColumnName("Senha")
                    .HasColumnType("varchar(255)")
                    .HasMaxLength(255)
                    .IsRequired();

                e.Property(x => x.Cargo)
                    .HasColumnName("Cargo")
                    .HasColumnType("int")
                    .IsRequired();

                e.HasMany(x => x.Tarefas)
                   .WithMany(x => x.Membros);

                e.HasMany(x => x.Projetos)
                   .WithOne(x => x.Gerente)
                   .HasForeignKey(x => x.GerenteId)
                    .OnDelete(DeleteBehavior.NoAction);
            });
        }
        public void TarefasBuilder(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tarefa>(e =>
            {
                e.ToTable(Table.Tarefa);

                e.HasKey(x => x.Id);

                e.Property(x => x.ProjetoId)
                   .HasColumnName("ProjetoId")
                   .IsRequired();

                e.Property(x => x.Nome)
                    .HasColumnName("Nome")
                    .HasColumnType("varchar(50)")
                    .HasMaxLength(50)
                    .IsRequired();

                e.Property(x => x.Descricao)
                    .HasColumnName("Descricao")
                    .HasColumnType("varchar(255)")
                    .HasMaxLength(255)
                    .IsRequired();

                e.Property(x => x.DataInicio)
                    .HasColumnName("DataInicio")
                    .HasColumnType("datetime")
                    .IsRequired();

                e.Property(x => x.DataPrazo)
                    .HasColumnName("DataPrazo")
                    .HasColumnType("datetime")
                    .IsRequired();

                e.Property(x => x.DataTermino)
                    .HasColumnName("DataTermino")
                    .HasColumnType("datetime")
                    .IsRequired(false);

                e.HasMany(x => x.Membros)
                    .WithMany(x => x.Tarefas);

                e.HasOne(x => x.Projeto)
                    .WithMany(x => x.Tarefas)
                    .HasForeignKey(x => x.ProjetoId)
                    .OnDelete(DeleteBehavior.NoAction);
            });
        }
    }
}
