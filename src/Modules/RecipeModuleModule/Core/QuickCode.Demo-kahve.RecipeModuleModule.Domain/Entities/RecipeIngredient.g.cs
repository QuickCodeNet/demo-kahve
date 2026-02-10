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

[Table("RECIPE_INGREDIENTS")]
public partial class RecipeIngredient : BaseSoftDeletable, IAuditableEntity 
{
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	[Column("ID")]
	public int Id { get; set; }
	
	[Column("RECIPE_ID")]
	public int RecipeId { get; set; }
	
	[Column("INGREDIENT_NAME")]
	[StringLength(250)]
	public string IngredientName { get; set; }
	
	[Column("QUANTITY")]
	public decimal Quantity { get; set; }
	
	[Column("UNIT")]
	[StringLength(250)]
	public string Unit { get; set; }
	
	[ForeignKey("RecipeId")]
	[InverseProperty("RecipeIngredients")]
	public virtual Recipe Recipe { get; set; } = null!;

}

