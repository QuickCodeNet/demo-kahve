using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using QuickCode.Demo-kahve.RecipeModuleModule.Domain;
using QuickCode.Demo-kahve.Common;
using QuickCode.Demo-kahve.Common.Auditing;

namespace QuickCode.Demo-kahve.RecipeModuleModule.Domain.Entities;

[Table("RECIPE_EQUIPMENTS")]
public partial class RecipeEquipment : BaseSoftDeletable, IAuditableEntity 
{
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	[Column("ID")]
	public int Id { get; set; }
	
	[Column("RECIPE_ID")]
	public int RecipeId { get; set; }
	
	[Column("EQUIPMENT_NAME")]
	[StringLength(250)]
	public string EquipmentName { get; set; }
	
	[Column("EQUIPMENT_DESCRIPTION")]
	[StringLength(250)]
	public string EquipmentDescription { get; set; }
	
	[ForeignKey("RecipeId")]
	[InverseProperty("RecipeEquipments")]
	public virtual Recipe Recipe { get; set; } = null!;

}

