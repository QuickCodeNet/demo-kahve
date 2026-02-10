using System;
using System.ComponentModel.DataAnnotations.Schema;
using QuickCode.Demo-kahve.Common;

namespace QuickCode.Demo-kahve.IdentityModule.Domain;

public class BaseSoftDeletable : ISoftDeletable
{
    [Column("IsDeleted")]
    public bool IsDeleted { get; set; }
    
    [Column("DeletedOnUtc")]
    public DateTime? DeletedOnUtc { get; set; }
}