using Microsoft.EntityFrameworkCore;
using Proj.Manager.Core.Entities;

namespace Proj.Manager.Infrastructure.Persistence.SQLServer
{
    public class SqlServerDBContext : DbContext
    {
        public SqlServerDBContext(DbContextOptions<SqlServerDBContext> options) : base(options)
        { }

        public DbSet<Project> Project { get; set; }
        public DbSet<Member> Member { get; set; }
        public DbSet<Core.Entities.Task> Task { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ProjectBuilder(modelBuilder);
            MemberBuilder(modelBuilder);
            TasksBuilder(modelBuilder);
        }

        public void ProjectBuilder(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Project>(e =>
            {
                e.ToTable(Table.Project);

                e.HasKey(x => x.Id);

                e.OwnsOne(x => x.Manager)
                    .Property(x => x.Id)
                    .HasColumnName("ManagerId")
                    .IsRequired();

                e.OwnsOne(x => x.Name)
                    .Property(x => x.Value)
                    .HasColumnName("Name")
                    .HasColumnType("varchar(50)")
                    .HasMaxLength(50)
                    .IsRequired();

                e.OwnsOne(x => x.Description)
                    .Property(x => x.Value)
                    .HasColumnName("Description")
                    .HasColumnType("varchar(255)")
                    .HasMaxLength(255)
                    .IsRequired();

                e.Property(x => x.StartDate)
                    .HasColumnName("StartDate")
                    .HasColumnType("datetime")
                    .IsRequired();

                e.Property(x => x.EndDate)
                   .HasColumnName("EndDate")
                   .HasColumnType("datetime")
                   .IsRequired();

                e.Property(x => x.FinishDate)
                   .HasColumnName("FinishDate")
                   .HasColumnType("datetime")
                   .IsRequired(false);

                e.Property(x => x.Status)
                   .HasColumnName("Status")
                   .HasColumnType("int");

                e.HasMany(x => x.Tasks)
                    .WithOne()
                    .HasForeignKey(x => x.ProjectId);

                e.HasOne(x => x.Manager)
                    .WithMany(x => x.Projects)
                    .HasForeignKey(x => x.ManagerId)
                    .OnDelete(DeleteBehavior.NoAction);
            });
        }
        public void MemberBuilder(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Member>(e =>
            {
                e.ToTable(Table.Member);

                e.HasKey(x => x.Id);

                e.OwnsOne(x => x.Name)
                    .Property(x => x.Value)
                    .HasColumnName("Name")
                    .HasColumnType("varchar(50)")
                    .HasMaxLength(50)
                    .IsRequired();

                e.OwnsOne(x => x.Email)
                    .Property(x => x.Value)
                    .HasColumnName("Email")
                    .HasColumnType("varchar(255)")
                    .HasMaxLength(255)
                    .IsRequired();

                e.OwnsOne(x => x.Password)
                    .Property(x => x.Value)
                    .HasColumnName("Password")
                    .HasColumnType("varchar(255)")
                    .HasMaxLength(255)
                    .IsRequired();

                e.Property(x => x.Role)
                    .HasColumnName("Role")
                    .HasColumnType("int")
                    .IsRequired();

                e.HasMany(x => x.Tasks)
                   .WithMany(x => x.Members);

                e.HasMany(x => x.Projects)
                   .WithOne(x => x.Manager)
                   .HasForeignKey(x => x.ManagerId)
                    .OnDelete(DeleteBehavior.NoAction);
            });
        }
        public void TasksBuilder(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Core.Entities.Task>(e =>
            {
                e.ToTable(Table.Task);

                e.HasKey(x => x.Id);

                e.Property(x => x.ProjectId)
                   .HasColumnName("ProjectId")
                   .IsRequired();

                e.OwnsOne(x => x.Name)
                    .Property(x => x.Value)
                    .HasColumnName("Name")
                    .HasColumnType("varchar(50)")
                    .HasMaxLength(50)
                    .IsRequired();

                e.OwnsOne(x => x.Description)
                    .Property(x => x.Value)
                    .HasColumnName("Description")
                    .HasColumnType("varchar(255)")
                    .HasMaxLength(255)
                    .IsRequired();

                e.Property(x => x.StartDate)
                    .HasColumnName("StartDate")
                    .HasColumnType("datetime")
                    .IsRequired();

                e.Property(x => x.FinishDate)
                    .HasColumnName("FinishDate")
                    .HasColumnType("datetime")
                    .IsRequired(false);

                e.HasMany(x => x.Members)
                    .WithMany(x => x.Tasks);

                e.HasOne(x => x.Project)
                    .WithMany(x => x.Tasks)
                    .HasForeignKey(x => x.ProjectId)
                    .OnDelete(DeleteBehavior.NoAction);
            });
        }
    }
}
