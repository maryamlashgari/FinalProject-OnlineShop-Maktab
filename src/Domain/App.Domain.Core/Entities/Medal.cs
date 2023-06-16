using System;
using System.Collections.Generic;

namespace App.Domain.Core.Entities;

public partial class Medal
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public double? Commission { get; set; }

    public double? SalesAmount { get; set; }
    public bool IsDeletedFlag { get; set; }

    public virtual ICollection<Booth> Booths { get; set; } = new List<Booth>();
}
