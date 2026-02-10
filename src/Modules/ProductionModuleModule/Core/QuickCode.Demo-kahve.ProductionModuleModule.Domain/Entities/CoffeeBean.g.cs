using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using QuickCode.Demo-kahve.ProductionModuleModule.Domain;
using QuickCode.Demo-kahve.Common;
using QuickCode.Demo-kahve.Common.Auditing;

namespace QuickCode.Demo-kahve.ProductionModuleModule.Domain.Entities;

[Table("COFFEE_BEANS")]
public partial class CoffeeBean : BaseSoftDeletable, IAuditableEntity 
{
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	[Column("ID")]
	public int Id { get; set; }
	
	[Column("BATCH_ID")]
	[StringLength(250)]
	public string BatchId { get; set; }
	
	[Column("ORIGIN")]
	[StringLength(250)]
	public string Origin { get; set; }
	
	[Column("WEIGHT_KG")]
	public decimal WeightKg { get; set; }
	
	[Column("ARRIVAL_DATE")]
	public DateTime ArrivalDate { get; set; }
	
	[Column("IS_ACTIVE")]
	public bool IsActive { get; set; }
	
	[Column("CREATED_DATE")]
	public DateTime CreatedDate { get; set; }
	
	[InverseProperty("BeanBatch")]
	public virtual ICollection<RoastingProcess> RoastingProcesses { get; } = new List<RoastingProcess>();

}

