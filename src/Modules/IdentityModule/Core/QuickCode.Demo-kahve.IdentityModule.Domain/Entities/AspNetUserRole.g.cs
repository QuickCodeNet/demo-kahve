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

[PrimaryKey("UserId", "RoleId")]
[Table("AspNetUserRoles")]
public partial class AspNetUserRole : IAuditableEntity 
{
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.None)]
	[Column("UserId")]
	[StringLength(450)]
	public string UserId { get; set; }
	
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.None)]
	[Column("RoleId")]
	[StringLength(450)]
	public string RoleId { get; set; }
	
	[ForeignKey("RoleId")]
	[InverseProperty("AspNetUserRoles")]
	public virtual AspNetRole Role { get; set; } = null!;


	[ForeignKey("UserId")]
	[InverseProperty("AspNetUserRoles")]
	public virtual AspNetUser User { get; set; } = null!;

}

