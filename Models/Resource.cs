using System;
using System.Collections.Generic;

namespace backend.Models;

public partial class Resource
{
    public int ResourceId { get; set; }

    public string ResourceName { get; set; } = null!;

    public string Description { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime ModifiedAt { get; set; }

    public bool IsActive { get; set; }

    public virtual ICollection<MedicalHistory> MedicalHistories { get; set; } = new List<MedicalHistory>();

    public virtual ICollection<ResourceCareTask> ResourceCareTasks { get; set; } = new List<ResourceCareTask>();

    public virtual ICollection<ResourceStock> ResourceStocks { get; set; } = new List<ResourceStock>();

    public virtual ICollection<ResourceTask> ResourceTasks { get; set; } = new List<ResourceTask>();
}
