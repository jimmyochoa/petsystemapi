using System;
using System.Collections.Generic;

namespace backend.Models;

public partial class CareTask
{
    public int CareTaskId { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime ModifiedAt { get; set; }

    public bool IsActive { get; set; }

    public virtual ICollection<PetCare> PetCares { get; set; } = new List<PetCare>();

    public virtual ICollection<ResourceCareTask> ResourceCareTasks { get; set; } = new List<ResourceCareTask>();

    public virtual ICollection<UserCareTask> UserCareTasks { get; set; } = new List<UserCareTask>();
}
