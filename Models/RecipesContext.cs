using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace SharpeningTheSaw.Models
{
    public partial class RecipesContext : DbContext
    {
        public RecipesContext()
        {
        }

        public RecipesContext(DbContextOptions<RecipesContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Ingredient> Ingredients { get; set; }
        public virtual DbSet<IngredientClass> IngredientClasses { get; set; }
        public virtual DbSet<Measurement> Measurements { get; set; }
        public virtual DbSet<Recipe> Recipes { get; set; }
        public virtual DbSet<RecipeClass> RecipeClasses { get; set; }
        public virtual DbSet<RecipeIngredient> RecipeIngredients { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlite("Data Source = Recipes.sqlite");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ingredient>(entity =>
            {
                entity.HasIndex(e => e.IngredientClassId, "Ingredient_ClassesIngredients");

                entity.HasIndex(e => e.MeasureAmountId, "MeasurementsIngredients");

                entity.Property(e => e.IngredientId)
                    .HasColumnType("int")
                    .ValueGeneratedNever()
                    .HasColumnName("IngredientID");

                entity.Property(e => e.IngredientClassId)
                    .HasColumnType("smallint")
                    .HasColumnName("IngredientClassID")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.IngredientName).HasColumnType("nvarchar (255)");

                entity.Property(e => e.MeasureAmountId)
                    .HasColumnType("smallint")
                    .HasColumnName("MeasureAmountID")
                    .HasDefaultValueSql("0");

                entity.HasOne(d => d.IngredientClass)
                    .WithMany(p => p.Ingredients)
                    .HasForeignKey(d => d.IngredientClassId);

                entity.HasOne(d => d.MeasureAmount)
                    .WithMany(p => p.Ingredients)
                    .HasForeignKey(d => d.MeasureAmountId);
            });

            modelBuilder.Entity<IngredientClass>(entity =>
            {
                entity.ToTable("Ingredient_Classes");

                entity.Property(e => e.IngredientClassId)
                    .HasColumnType("smallint")
                    .ValueGeneratedNever()
                    .HasColumnName("IngredientClassID");

                entity.Property(e => e.IngredientClassDescription).HasColumnType("nvarchar (255)");
            });

            modelBuilder.Entity<Measurement>(entity =>
            {
                entity.HasKey(e => e.MeasureAmountId);

                entity.Property(e => e.MeasureAmountId)
                    .HasColumnType("smallint")
                    .ValueGeneratedNever()
                    .HasColumnName("MeasureAmountID");

                entity.Property(e => e.MeasurementDescription).HasColumnType("nvarchar (255)");
            });

            modelBuilder.Entity<Recipe>(entity =>
            {
                entity.HasIndex(e => e.RecipeClassId, "Recipe_ClassesRecipes");

                entity.Property(e => e.RecipeId)
                    .HasColumnType("int")
                    .ValueGeneratedNever()
                    .HasColumnName("RecipeID");

                entity.Property(e => e.Notes).HasColumnType("text");

                entity.Property(e => e.Preparation).HasColumnType("text");

                entity.Property(e => e.RecipeClassId)
                    .HasColumnType("smallint")
                    .HasColumnName("RecipeClassID")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.RecipeTitle).HasColumnType("nvarchar (255)");

                entity.HasOne(d => d.RecipeClass)
                    .WithMany(p => p.Recipes)
                    .HasForeignKey(d => d.RecipeClassId);
            });

            modelBuilder.Entity<RecipeClass>(entity =>
            {
                entity.ToTable("Recipe_Classes");

                entity.Property(e => e.RecipeClassId)
                    .HasColumnType("smallint")
                    .ValueGeneratedNever()
                    .HasColumnName("RecipeClassID");

                entity.Property(e => e.RecipeClassDescription).HasColumnType("nvarchar (255)");
            });

            modelBuilder.Entity<RecipeIngredient>(entity =>
            {
                entity.HasKey(e => new { e.RecipeId, e.RecipeSeqNo });

                entity.ToTable("Recipe_Ingredients");

                entity.HasIndex(e => e.IngredientId, "IngredientID");

                entity.HasIndex(e => e.MeasureAmountId, "MeasureAmountID");

                entity.HasIndex(e => e.RecipeId, "RecipeID");

                entity.Property(e => e.RecipeId)
                    .HasColumnType("int")
                    .HasColumnName("RecipeID");

                entity.Property(e => e.RecipeSeqNo).HasColumnType("smallint");

                entity.Property(e => e.Amount)
                    .HasColumnType("real")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.IngredientId)
                    .HasColumnType("int")
                    .HasColumnName("IngredientID")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.MeasureAmountId)
                    .HasColumnType("smallint")
                    .HasColumnName("MeasureAmountID")
                    .HasDefaultValueSql("0");

                entity.HasOne(d => d.Ingredient)
                    .WithMany(p => p.RecipeIngredients)
                    .HasForeignKey(d => d.IngredientId);

                entity.HasOne(d => d.MeasureAmount)
                    .WithMany(p => p.RecipeIngredients)
                    .HasForeignKey(d => d.MeasureAmountId);

                entity.HasOne(d => d.Recipe)
                    .WithMany(p => p.RecipeIngredients)
                    .HasForeignKey(d => d.RecipeId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
