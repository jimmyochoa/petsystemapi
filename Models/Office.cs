using System;
using System.Collections.Generic;

namespace backend.Models;

public partial class Office
{
    public int OfficeId { get; set; }

    public string OfficeName { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string Direction { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime ModifiedAt { get; set; }

    public bool IsActive { get; set; }

    public int CityId { get; set; }

    public virtual City City { get; set; } = null!;

    public virtual ICollection<ResourceStock> ResourceStocks { get; set; } = new List<ResourceStock>();

    public virtual ICollection<UserCareTask> UserCareTasks { get; set; } = new List<UserCareTask>();

    public virtual ICollection<UserTask> UserTasks { get; set; } = new List<UserTask>();
}
