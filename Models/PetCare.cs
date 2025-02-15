using System;
using System.Collections.Generic;

namespace backend.Models;

public partial class PetCare
{
    public int PetCareTaskId { get; set; }

    public int PetId { get; set; }

    public int CareTaskId { get; set; }

    public string Description { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime ModifiedAt { get; set; }

    public bool IsActive { get; set; }

    public virtual CareTask CareTask { get; set; } = null!;

    public virtual Pet Pet { get; set; } = null!;
}
