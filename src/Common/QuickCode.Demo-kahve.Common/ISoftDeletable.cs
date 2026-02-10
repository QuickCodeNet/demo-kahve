using System.ComponentModel.DataAnnotations.Schema;

namespace QuickCode.Demo-kahve.Common;

public interface ISoftDeletable
{
    bool IsDeleted { get; set; }
    DateTime? DeletedOnUtc { get; set; }
}