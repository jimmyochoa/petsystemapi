using System;
using System.Collections.Generic;

namespace backend.Models;

public partial class UserCareTask
{
    public int UserCareTaskId { get; set; }

    public int UserId { get; set; }

    public int OfficeId { get; set; }

    public int PriorityId { get; set; }

    public int StatusId { get; set; }

    public int CareTaskId { get; set; }

    public string Description { get; set; } = null!;

    public DateTime ExpDate { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime ModifiedAt { get; set; }

    public bool IsActive { get; set; }

    public virtual CareTask CareTask { get; set; } = null!;

    public virtual Office Office { get; set; } = null!;

    public virtual Priority Priority { get; set; } = null!;

    public virtual Status Status { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
