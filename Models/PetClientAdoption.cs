using System;
using System.Collections.Generic;

namespace backend.Models;

public partial class PetClientAdoption
{
    public int AdoptionId { get; set; }

    public int ClientId { get; set; }

    public int PetId { get; set; }

    public string Description { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime ModifiedAt { get; set; }

    public bool IsActive { get; set; }

    public virtual Client Client { get; set; } = null!;

    public virtual Pet Pet { get; set; } = null!;
}
