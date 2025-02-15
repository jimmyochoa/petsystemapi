using System;
using System.Collections.Generic;

namespace backend.Models;

public partial class Status
{
    public int StatusId { get; set; }

    public string StatusName { get; set; } = null!;

    public string Description { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime ModifiedAt { get; set; }

    public bool IsActive { get; set; }

    public virtual ICollection<UserCareTask> UserCareTasks { get; set; } = new List<UserCareTask>();

    public virtual ICollection<UserTask> UserTasks { get; set; } = new List<UserTask>();
}
