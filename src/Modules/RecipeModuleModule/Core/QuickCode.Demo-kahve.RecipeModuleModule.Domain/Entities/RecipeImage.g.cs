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

[Table("RECIPE_IMAGES")]
public partial class RecipeImage : BaseSoftDeletable, IAuditableEntity 
{
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	[Column("ID")]
	public int Id { get; set; }
	
	[Column("RECIPE_ID")]
	public int RecipeId { get; set; }
	
	[Column("IMAGE_URL")]
	[StringLength(500)]
	public string ImageUrl { get; set; }
	
	[Column("DESCRIPTION")]
	[StringLength(250)]
	public string Description { get; set; }
	
	[ForeignKey("RecipeId")]
	[InverseProperty("RecipeImages")]
	public virtual Recipe Recipe { get; set; } = null!;

}

