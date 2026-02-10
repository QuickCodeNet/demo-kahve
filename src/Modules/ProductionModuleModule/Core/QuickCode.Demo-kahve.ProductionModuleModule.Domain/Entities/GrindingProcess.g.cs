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

[Table("GRINDING_PROCESSES")]
public partial class GrindingProcess : BaseSoftDeletable, IAuditableEntity 
{
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	[Column("ID")]
	public int Id { get; set; }
	
	[Column("ROASTING_PROCESS_ID")]
	public int RoastingProcessId { get; set; }
	
	[Column("GRINDING_DATE")]
	public DateTime GrindingDate { get; set; }
	
	[Column("GRIND_SIZE")]
	[StringLength(250)]
	public string GrindSize { get; set; }
	
	[Column("PROCESS_STATUS", TypeName = "nvarchar(250)")]
	public ProcessStatus ProcessStatus { get; set; }
	
	[Column("CREATED_DATE")]
	public DateTime CreatedDate { get; set; }
	
	[InverseProperty("GrindingProcess")]
	public virtual ICollection<PackagingProcess> PackagingProcesses { get; } = new List<PackagingProcess>();


	[ForeignKey("RoastingProcessId")]
	[InverseProperty("GrindingProcesses")]
	public virtual RoastingProcess RoastingProcess { get; set; } = null!;

}

