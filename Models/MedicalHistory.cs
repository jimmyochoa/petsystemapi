using System;
using System.Collections.Generic;

namespace backend.Models;

public partial class MedicalHistory
{
    public int MedicalHistoryId { get; set; }

    public int PetId { get; set; }

    public int ResourceId { get; set; }

    public string Description { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime ModifiedAt { get; set; }

    public bool IsActive { get; set; }

    public virtual Pet Pet { get; set; } = null!;

    public virtual Resource Resource { get; set; } = null!;
}
