using System;
using System.Collections.Generic;

namespace backend.Models;

public partial class ResourceStock
{
    public int ResourceStockId { get; set; }

    public int ResourceId { get; set; }

    public int OfficeId { get; set; }

    public string Description { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime ModifiedAt { get; set; }

    public bool IsActive { get; set; }

    public virtual Office Office { get; set; } = null!;

    public virtual Resource Resource { get; set; } = null!;
}
