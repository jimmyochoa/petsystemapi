using System;
using System.Collections.Generic;

namespace backend.Models;

public partial class Pet
{
    public int PetId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Description { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime ModifiedAt { get; set; }

    public bool IsActive { get; set; }

    public int PetTypeId { get; set; }

    public virtual ICollection<MedicalHistory> MedicalHistories { get; set; } = new List<MedicalHistory>();

    public virtual ICollection<PetCare> PetCares { get; set; } = new List<PetCare>();

    public virtual ICollection<PetClientAdoption> PetClientAdoptions { get; set; } = new List<PetClientAdoption>();

    public virtual PetType PetType { get; set; } = null!;
}
