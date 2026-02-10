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

[Table("ROASTING_PROCESSES")]
public partial class RoastingProcess : BaseSoftDeletable, IAuditableEntity 
{
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	[Column("ID")]
	public int Id { get; set; }
	
	[Column("BEAN_BATCH_ID")]
	public int BeanBatchId { get; set; }
	
	[Column("ROASTING_DATE")]
	public DateTime RoastingDate { get; set; }
	
	[Column("TEMPERATURE_CELSIUS")]
	public int TemperatureCelsius { get; set; }
	
	[Column("DURATION_MINUTES")]
	public int DurationMinutes { get; set; }
	
	[Column("PROCESS_STATUS", TypeName = "nvarchar(250)")]
	public ProcessStatus ProcessStatus { get; set; }
	
	[Column("CREATED_DATE")]
	public DateTime CreatedDate { get; set; }
	
	[InverseProperty("RoastingProcess")]
	public virtual ICollection<GrindingProcess> GrindingProcesses { get; } = new List<GrindingProcess>();


	[ForeignKey("BeanBatchId")]
	[InverseProperty("RoastingProcesses")]
	public virtual CoffeeBean BeanBatch { get; set; } = null!;

}

