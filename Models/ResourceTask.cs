using System;
using System.Collections.Generic;

namespace backend.Models;

public partial class ResourceTask
{
    public int ResourceTaskId { get; set; }

    public int ResourceId { get; set; }

    public int TaskId { get; set; }

    public string Description { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime ModifiedAt { get; set; }

    public bool IsActive { get; set; }

    public virtual Resource Resource { get; set; } = null!;

    public virtual Task Task { get; set; } = null!;
}
