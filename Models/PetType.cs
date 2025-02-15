using System;
using System.Collections.Generic;

namespace backend.Models;

public partial class PetType
{
    public int PetTypeId { get; set; }

    public string PetTypeName { get; set; } = null!;

    public string Description { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime ModifiedAt { get; set; }

    public bool IsActive { get; set; }

    public virtual ICollection<Pet> Pets { get; set; } = new List<Pet>();
}
