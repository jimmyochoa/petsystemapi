using System;
using System.Collections.Generic;

namespace backend.Models;

public partial class UserTask
{
    public int UserTaskId { get; set; }

    public int UserId { get; set; }

    public int StatusId { get; set; }

    public int OfficeId { get; set; }

    public int PriorityId { get; set; }

    public int TaskId { get; set; }

    public string Description { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime ModifiedAt { get; set; }

    public bool IsActive { get; set; }

    public virtual Office Office { get; set; } = null!;

    public virtual Priority Priority { get; set; } = null!;

    public virtual Status Status { get; set; } = null!;

    public virtual Task Task { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
