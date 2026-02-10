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

[Table("PRODUCTION_ERRORS")]
public partial class ProductionError : BaseSoftDeletable, IAuditableEntity 
{
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	[Column("ID")]
	public int Id { get; set; }
	
	[Column("PROCESS_ID")]
	public int ProcessId { get; set; }
	
	[Column("ERROR_DATE")]
	public DateTime ErrorDate { get; set; }
	
	[Column("ERROR_DESCRIPTION")]
	[StringLength(250)]
	public string ErrorDescription { get; set; }
	
	[Column("ERROR_SEVERITY")]
	[StringLength(250)]
	public string ErrorSeverity { get; set; }
	
	[Column("CREATED_DATE")]
	public DateTime CreatedDate { get; set; }
	}

