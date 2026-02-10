using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using QuickCode.Demo-kahve.ProductionModuleModule.Domain;
using QuickCode.Demo-kahve.Common;
using QuickCode.Demo-kahve.Common.Auditing;
using QuickCode.Demo-kahve.ProductionModuleModule.Domain.Enums;

namespace QuickCode.Demo-kahve.ProductionModuleModule.Domain.Entities;

[Table("PACKAGING_PROCESSES")]
public partial class PackagingProcess : BaseSoftDeletable, IAuditableEntity 
{
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	[Column("ID")]
	public int Id { get; set; }
	
	[Column("GRINDING_PROCESS_ID")]
	public int GrindingProcessId { get; set; }
	
	[Column("PACKAGING_DATE")]
	public DateTime PackagingDate { get; set; }
	
	[Column("PACKAGE_SIZE_GRAMS")]
	public int PackageSizeGrams { get; set; }
	
	[Column("PROCESS_STATUS", TypeName = "nvarchar(250)")]
	public ProcessStatus ProcessStatus { get; set; }
	
	[Column("CREATED_DATE")]
	public DateTime CreatedDate { get; set; }
	
	[ForeignKey("GrindingProcessId")]
	[InverseProperty("PackagingProcesses")]
	public virtual GrindingProcess GrindingProcess { get; set; } = null!;

}

