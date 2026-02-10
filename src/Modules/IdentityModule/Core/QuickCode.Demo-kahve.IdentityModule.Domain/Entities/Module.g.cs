using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using QuickCode.Demo-kahve.IdentityModule.Domain;
using QuickCode.Demo-kahve.Common;
using QuickCode.Demo-kahve.Common.Auditing;

namespace QuickCode.Demo-kahve.IdentityModule.Domain.Entities;

[Table("Modules")]
public partial class Module : IAuditableEntity 
{
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.None)]
	[Column("Name")]
	[StringLength(1000)]
	public string Name { get; set; }
	
	[Column("Description")]
	[StringLength(1000)]
	public string Description { get; set; }
	
	[InverseProperty("Module")]
	public virtual ICollection<Model> Models { get; } = new List<Model>();


	[InverseProperty("Module")]
	public virtual ICollection<ApiMethodDefinition> ApiMethodDefinitions { get; } = new List<ApiMethodDefinition>();


	[InverseProperty("Module")]
	public virtual ICollection<PortalPageDefinition> PortalPageDefinitions { get; } = new List<PortalPageDefinition>();

}

