using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using QuickCode.Demo-kahve.RecipeModuleModule.Domain.Entities;

namespace QuickCode.Demo-kahve.RecipeModuleModule.Persistence.Contexts;

public partial class WriteDbContext : DbContext
{
	public WriteDbContext(DbContextOptions<WriteDbContext> options) : base(options) { }


	public virtual DbSet<Recipe> Recipe { get; set; }

	public virtual DbSet<RecipeIngredient> RecipeIngredient { get; set; }

	public virtual DbSet<RecipeEquipment> RecipeEquipment { get; set; }

	public virtual DbSet<RecipeNote> RecipeNote { get; set; }

	public virtual DbSet<RecipeImage> RecipeImage { get; set; }

	public virtual DbSet<RecipeCategory> RecipeCategory { get; set; }

	public virtual DbSet<RecipeCategoryAssignment> RecipeCategoryAssignment { get; set; }

	public virtual DbSet<AuditLog> AuditLog { get; set; }


	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<Recipe>()
		.Property(b => b.IsActive)
		.IsRequired()
		.HasDefaultValue(false);

		modelBuilder.Entity<RecipeCategory>()
		.Property(b => b.IsActive)
		.IsRequired()
		.HasDefaultValue(false);

		modelBuilder.Entity<AuditLog>()
		.Property(b => b.IsChanged)
		.IsRequired()
		.HasDefaultValue(true);

		modelBuilder.Entity<AuditLog>()
		.Property(b => b.IsSuccess)
		.IsRequired()
		.HasDefaultValue(true);

		modelBuilder.Entity<Recipe>().Property(b => b.IsDeleted).IsRequired().HasDefaultValue(false);
		modelBuilder.Entity<Recipe>().HasQueryFilter(r => !r.IsDeleted);

		modelBuilder.Entity<RecipeIngredient>().Property(b => b.IsDeleted).IsRequired().HasDefaultValue(false);
		modelBuilder.Entity<RecipeIngredient>().HasQueryFilter(r => !r.IsDeleted);

		modelBuilder.Entity<RecipeEquipment>().Property(b => b.IsDeleted).IsRequired().HasDefaultValue(false);
		modelBuilder.Entity<RecipeEquipment>().HasQueryFilter(r => !r.IsDeleted);

		modelBuilder.Entity<RecipeNote>().Property(b => b.IsDeleted).IsRequired().HasDefaultValue(false);
		modelBuilder.Entity<RecipeNote>().HasQueryFilter(r => !r.IsDeleted);

		modelBuilder.Entity<RecipeImage>().Property(b => b.IsDeleted).IsRequired().HasDefaultValue(false);
		modelBuilder.Entity<RecipeImage>().HasQueryFilter(r => !r.IsDeleted);

		modelBuilder.Entity<RecipeCategory>().Property(b => b.IsDeleted).IsRequired().HasDefaultValue(false);
		modelBuilder.Entity<RecipeCategory>().HasQueryFilter(r => !r.IsDeleted);

		modelBuilder.Entity<RecipeCategoryAssignment>().Property(b => b.IsDeleted).IsRequired().HasDefaultValue(false);
		modelBuilder.Entity<RecipeCategoryAssignment>().HasQueryFilter(r => !r.IsDeleted);


		modelBuilder.Entity<Recipe>().HasIndex(r => r.IsDeleted).HasFilter("IsDeleted = 0");
		modelBuilder.Entity<RecipeIngredient>().HasIndex(r => r.IsDeleted).HasFilter("IsDeleted = 0");
		modelBuilder.Entity<RecipeEquipment>().HasIndex(r => r.IsDeleted).HasFilter("IsDeleted = 0");
		modelBuilder.Entity<RecipeNote>().HasIndex(r => r.IsDeleted).HasFilter("IsDeleted = 0");
		modelBuilder.Entity<RecipeImage>().HasIndex(r => r.IsDeleted).HasFilter("IsDeleted = 0");
		modelBuilder.Entity<RecipeCategory>().HasIndex(r => r.IsDeleted).HasFilter("IsDeleted = 0");
		modelBuilder.Entity<RecipeCategoryAssignment>().HasIndex(r => r.IsDeleted).HasFilter("IsDeleted = 0");


		modelBuilder.Entity<RecipeIngredient>()
			.HasOne(e => e.Recipe)
			.WithMany(p => p.RecipeIngredients)
			.HasForeignKey(e => e.RecipeId)
			.OnDelete(DeleteBehavior.Restrict);

		modelBuilder.Entity<RecipeEquipment>()
			.HasOne(e => e.Recipe)
			.WithMany(p => p.RecipeEquipments)
			.HasForeignKey(e => e.RecipeId)
			.OnDelete(DeleteBehavior.Restrict);

		modelBuilder.Entity<RecipeNote>()
			.HasOne(e => e.Recipe)
			.WithMany(p => p.RecipeNotes)
			.HasForeignKey(e => e.RecipeId)
			.OnDelete(DeleteBehavior.Restrict);

		modelBuilder.Entity<RecipeImage>()
			.HasOne(e => e.Recipe)
			.WithMany(p => p.RecipeImages)
			.HasForeignKey(e => e.RecipeId)
			.OnDelete(DeleteBehavior.Restrict);

		modelBuilder.Entity<RecipeCategoryAssignment>()
			.HasOne(e => e.Recipe)
			.WithMany(p => p.RecipeCategoryAssignments)
			.HasForeignKey(e => e.RecipeId)
			.OnDelete(DeleteBehavior.Restrict);

		modelBuilder.Entity<RecipeCategoryAssignment>()
			.HasOne(e => e.Category)
			.WithMany(p => p.RecipeCategoryAssignments)
			.HasForeignKey(e => e.CategoryId)
			.OnDelete(DeleteBehavior.Restrict);

		OnModelCreatingPartial(modelBuilder);
	}

	partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
