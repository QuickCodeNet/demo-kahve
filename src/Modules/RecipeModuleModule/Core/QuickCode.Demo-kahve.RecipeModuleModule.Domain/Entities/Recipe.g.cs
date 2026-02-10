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

[Table("RECIPES")]
public partial class Recipe : BaseSoftDeletable, IAuditableEntity 
{
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	[Column("ID")]
	public int Id { get; set; }
	
	[Column("RECIPE_NAME")]
	[StringLength(250)]
	public string RecipeName { get; set; }
	
	[Column("DESCRIPTION")]
	[StringLength(250)]
	public string Description { get; set; }
	
	[Column("INSTRUCTIONS")]
	[StringLength(int.MaxValue)]
	public string Instructions { get; set; }
	
	[Column("CREATED_DATE")]
	public DateTime CreatedDate { get; set; }
	
	[Column("IS_ACTIVE")]
	public bool IsActive { get; set; }
	
	[InverseProperty("Recipe")]
	public virtual ICollection<RecipeIngredient> RecipeIngredients { get; } = new List<RecipeIngredient>();


	[InverseProperty("Recipe")]
	public virtual ICollection<RecipeEquipment> RecipeEquipments { get; } = new List<RecipeEquipment>();


	[InverseProperty("Recipe")]
	public virtual ICollection<RecipeNote> RecipeNotes { get; } = new List<RecipeNote>();


	[InverseProperty("Recipe")]
	public virtual ICollection<RecipeImage> RecipeImages { get; } = new List<RecipeImage>();


	[InverseProperty("Recipe")]
	public virtual ICollection<RecipeCategoryAssignment> RecipeCategoryAssignments { get; } = new List<RecipeCategoryAssignment>();

}

