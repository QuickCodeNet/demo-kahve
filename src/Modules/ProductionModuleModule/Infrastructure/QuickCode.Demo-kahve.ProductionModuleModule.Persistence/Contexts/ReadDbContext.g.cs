using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using QuickCode.Demo-kahve.ProductionModuleModule.Domain.Entities;
using QuickCode.Demo-kahve.ProductionModuleModule.Domain.Enums;

namespace QuickCode.Demo-kahve.ProductionModuleModule.Persistence.Contexts;

public partial class ReadDbContext : DbContext
{
	public ReadDbContext(DbContextOptions<ReadDbContext> options) : base(options) { }


	public virtual DbSet<CoffeeBean> CoffeeBean { get; set; }

	public virtual DbSet<RoastingProcess> RoastingProcess { get; set; }

	public virtual DbSet<GrindingProcess> GrindingProcess { get; set; }

	public virtual DbSet<PackagingProcess> PackagingProcess { get; set; }

	public virtual DbSet<ProductionError> ProductionError { get; set; }

	public virtual DbSet<ProcessEquipment> ProcessEquipment { get; set; }

	public virtual DbSet<AuditLog> AuditLog { get; set; }


	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<CoffeeBean>()
		.Property(b => b.IsActive)
		.IsRequired()
		.HasDefaultValue(false);


		var converterRoastingProcessProcessStatus = new ValueConverter<ProcessStatus, string>(
		v => v.ToString(),
		v => (ProcessStatus)Enum.Parse(typeof(ProcessStatus), v));

		modelBuilder.Entity<RoastingProcess>()
		.Property(b => b.ProcessStatus)
		.HasConversion(converterRoastingProcessProcessStatus);


		var converterGrindingProcessProcessStatus = new ValueConverter<ProcessStatus, string>(
		v => v.ToString(),
		v => (ProcessStatus)Enum.Parse(typeof(ProcessStatus), v));

		modelBuilder.Entity<GrindingProcess>()
		.Property(b => b.ProcessStatus)
		.HasConversion(converterGrindingProcessProcessStatus);


		var converterPackagingProcessProcessStatus = new ValueConverter<ProcessStatus, string>(
		v => v.ToString(),
		v => (ProcessStatus)Enum.Parse(typeof(ProcessStatus), v));

		modelBuilder.Entity<PackagingProcess>()
		.Property(b => b.ProcessStatus)
		.HasConversion(converterPackagingProcessProcessStatus);

		modelBuilder.Entity<ProcessEquipment>()
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

		modelBuilder.Entity<CoffeeBean>().Property(b => b.IsDeleted).IsRequired().HasDefaultValue(false);
		modelBuilder.Entity<CoffeeBean>().HasQueryFilter(r => !r.IsDeleted);

		modelBuilder.Entity<RoastingProcess>().Property(b => b.IsDeleted).IsRequired().HasDefaultValue(false);
		modelBuilder.Entity<RoastingProcess>().HasQueryFilter(r => !r.IsDeleted);

		modelBuilder.Entity<GrindingProcess>().Property(b => b.IsDeleted).IsRequired().HasDefaultValue(false);
		modelBuilder.Entity<GrindingProcess>().HasQueryFilter(r => !r.IsDeleted);

		modelBuilder.Entity<PackagingProcess>().Property(b => b.IsDeleted).IsRequired().HasDefaultValue(false);
		modelBuilder.Entity<PackagingProcess>().HasQueryFilter(r => !r.IsDeleted);

		modelBuilder.Entity<ProductionError>().Property(b => b.IsDeleted).IsRequired().HasDefaultValue(false);
		modelBuilder.Entity<ProductionError>().HasQueryFilter(r => !r.IsDeleted);

		modelBuilder.Entity<ProcessEquipment>().Property(b => b.IsDeleted).IsRequired().HasDefaultValue(false);
		modelBuilder.Entity<ProcessEquipment>().HasQueryFilter(r => !r.IsDeleted);


		modelBuilder.Entity<CoffeeBean>().HasIndex(r => r.IsDeleted).HasFilter("IsDeleted = 0");
		modelBuilder.Entity<RoastingProcess>().HasIndex(r => r.IsDeleted).HasFilter("IsDeleted = 0");
		modelBuilder.Entity<GrindingProcess>().HasIndex(r => r.IsDeleted).HasFilter("IsDeleted = 0");
		modelBuilder.Entity<PackagingProcess>().HasIndex(r => r.IsDeleted).HasFilter("IsDeleted = 0");
		modelBuilder.Entity<ProductionError>().HasIndex(r => r.IsDeleted).HasFilter("IsDeleted = 0");
		modelBuilder.Entity<ProcessEquipment>().HasIndex(r => r.IsDeleted).HasFilter("IsDeleted = 0");


		modelBuilder.Entity<RoastingProcess>()
			.HasOne(e => e.BeanBatch)
			.WithMany(p => p.RoastingProcesses)
			.HasForeignKey(e => e.BeanBatchId)
			.OnDelete(DeleteBehavior.Restrict);

		modelBuilder.Entity<GrindingProcess>()
			.HasOne(e => e.RoastingProcess)
			.WithMany(p => p.GrindingProcesses)
			.HasForeignKey(e => e.RoastingProcessId)
			.OnDelete(DeleteBehavior.Restrict);

		modelBuilder.Entity<PackagingProcess>()
			.HasOne(e => e.GrindingProcess)
			.WithMany(p => p.PackagingProcesses)
			.HasForeignKey(e => e.GrindingProcessId)
			.OnDelete(DeleteBehavior.Restrict);

		OnModelCreatingPartial(modelBuilder);
	}

	partial void OnModelCreatingPartial(ModelBuilder modelBuilder);


    public override int SaveChanges()
    {
        throw new InvalidOperationException("ReadDbContext is read-only.");
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        throw new InvalidOperationException("ReadDbContext is read-only.");
    }

}
