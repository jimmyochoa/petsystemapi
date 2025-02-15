using System;
using System.Collections.Generic;

namespace backend.Models;

public partial class PermissionRole
{
    public int PermissionRoleId { get; set; }

    public int RoleId { get; set; }

    public int PermissionId { get; set; }

    public string Description { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime ModifiedAt { get; set; }

    public bool IsActive { get; set; }

    public virtual Permission Permission { get; set; } = null!;

    public virtual Role Role { get; set; } = null!;
}
