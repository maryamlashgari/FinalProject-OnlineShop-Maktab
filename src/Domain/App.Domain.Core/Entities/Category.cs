using System;
using System.Collections.Generic;

namespace App.Domain.Core.Entities;

public partial class Category
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int? ParentId { get; set; }

    public string? Description { get; set; }

    public int? CreatedByUserId { get; set; }

    public DateTime? CreatedDateTime { get; set; }
    public bool IsDeletedFlag { get; set; }

    public virtual ICollection<Category> InverseParent { get; set; } = new List<Category>();

    public virtual Category? Parent { get; set; }
}
