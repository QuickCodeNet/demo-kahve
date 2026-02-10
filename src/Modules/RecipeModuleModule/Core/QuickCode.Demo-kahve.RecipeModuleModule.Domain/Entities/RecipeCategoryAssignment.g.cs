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

[Table("RECIPE_CATEGORY_ASSIGNMENTS")]
public partial class RecipeCategoryAssignment : BaseSoftDeletable, IAuditableEntity 
{
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	[Column("ID")]
	public int Id { get; set; }
	
	[Column("RECIPE_ID")]
	public int RecipeId { get; set; }
	
	[Column("CATEGORY_ID")]
	public int CategoryId { get; set; }
	
	[ForeignKey("RecipeId")]
	[InverseProperty("RecipeCategoryAssignments")]
	public virtual Recipe Recipe { get; set; } = null!;


	[ForeignKey("CategoryId")]
	[InverseProperty("RecipeCategoryAssignments")]
	public virtual RecipeCategory Category { get; set; } = null!;

}

