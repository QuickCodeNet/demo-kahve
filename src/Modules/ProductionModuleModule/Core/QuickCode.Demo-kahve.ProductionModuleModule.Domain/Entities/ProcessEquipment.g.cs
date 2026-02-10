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

[Table("PROCESS_EQUIPMENTS")]
public partial class ProcessEquipment : BaseSoftDeletable, IAuditableEntity 
{
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	[Column("ID")]
	public int Id { get; set; }
	
	[Column("EQUIPMENT_NAME")]
	[StringLength(250)]
	public string EquipmentName { get; set; }
	
	[Column("EQUIPMENT_TYPE")]
	[StringLength(250)]
	public string EquipmentType { get; set; }
	
	[Column("LAST_MAINTENANCE_DATE")]
	public DateTime LastMaintenanceDate { get; set; }
	
	[Column("IS_ACTIVE")]
	public bool IsActive { get; set; }
	
	[Column("CREATED_DATE")]
	public DateTime CreatedDate { get; set; }
	}

