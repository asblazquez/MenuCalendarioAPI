using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace Infraestructure.DAL.Context
{
    public partial class BDContext : DbContext
    {
        public BDContext(DbContextOptions<BDContext> options) : base(options)
        {
        }

        public BDContext()
        {
        }

        public virtual DbSet<Day> Days { get; set; }

        public virtual DbSet<Ingredient> Ingredients { get; set; }

        public virtual DbSet<Menu> Menus { get; set; }

        public virtual DbSet<Step> Steps { get; set; }

        public virtual DbSet<StepIngridient> StepIngridients { get; set; }

        public virtual DbSet<Store> Stores { get; set; }

        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
            => optionsBuilder.UseSqlServer("Server=PCANDRES;Database=MenuCalendar;Trusted_Connection=True;Encrypt=False");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Day>(entity =>
            {
                entity.ToTable("Day");

                entity.HasOne(d => d.Dinner).WithMany(p => p.Dinners)
                    .HasForeignKey(d => d.IdDinner)
                    .HasConstraintName("FK_Day_Dinner");

                entity.HasOne(d => d.Meal).WithMany(p => p.Meals)
                    .HasForeignKey(d => d.IdMeal)
                    .HasConstraintName("FK_Day_Meal");
            });

            modelBuilder.Entity<Ingredient>(entity =>
            {
                entity.ToTable("Ingredient");

                entity.Property(e => e.Description)
                    .HasMaxLength(150)
                    .IsUnicode(false);
                entity.Property(e => e.Title)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Menu>(entity =>
            {
                entity.ToTable("Menu");

                entity.Property(e => e.Description)
                    .HasMaxLength(250)
                    .IsUnicode(false);
                entity.Property(e => e.Title)
                    .HasMaxLength(150)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Step>(entity =>
            {
                entity.ToTable("Step");

                entity.Property(e => e.Description)
                    .HasMaxLength(250)
                    .IsUnicode(false);
                entity.Property(e => e.Title)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.HasOne(d => d.Menu).WithMany(p => p.Steps)
                    .HasForeignKey(d => d.IdMenu)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Step_Menu");
            });

            modelBuilder.Entity<StepIngridient>(entity =>
            {
                entity
                    .HasNoKey()
                    .ToTable("StepIngridient");

                entity.HasOne(d => d.Ingridient).WithMany()
                    .HasForeignKey(d => d.IdIngridient)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StepIngridient_Ingridient");

                entity.HasOne(d => d.Step).WithMany()
                    .HasForeignKey(d => d.IdStep)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StepIngridient_Step");
            });

            modelBuilder.Entity<Store>(entity =>
            {
                entity.ToTable("Store", "master");

                entity.Property(e => e.Name)
                    .HasMaxLength(150)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.Email)
                    .HasMaxLength(150)
                    .IsUnicode(false);
                entity.Property(e => e.LastName)
                    .HasMaxLength(150)
                    .IsUnicode(false);
                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.Password)
                    .HasMaxLength(150)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
