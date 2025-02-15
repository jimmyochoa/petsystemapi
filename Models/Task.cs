using System;
using System.Collections.Generic;

namespace backend.Models;

public partial class Task
{
    public int TaskId { get; set; }

    public string TaskName { get; set; } = null!;

    public string Description { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime ModifiedAt { get; set; }

    public bool IsActive { get; set; }

    public virtual ICollection<ResourceTask> ResourceTasks { get; set; } = new List<ResourceTask>();

    public virtual ICollection<UserTask> UserTasks { get; set; } = new List<UserTask>();
}
