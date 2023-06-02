using System;
using System.Collections.Generic;

namespace App.Domain.Core.Entities;

public partial class Chategory
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int? ParentId { get; set; }

    public string? Description { get; set; }

    public int? CreatedByUserId { get; set; }

    public DateTime? CreatedDateTime { get; set; }

    public virtual ICollection<Chategory> InverseParent { get; set; } = new List<Chategory>();

    public virtual Chategory? Parent { get; set; }
}
