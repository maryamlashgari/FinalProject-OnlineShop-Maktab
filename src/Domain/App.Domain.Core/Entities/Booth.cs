using System;
using System.Collections.Generic;

namespace App.Domain.Core.Entities;

public partial class Booth
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int? UserId { get; set; }

    public string CathIdsCsv { get; set; } = null!;

    public int? MedalId { get; set; }

    public int? CreatedByUserId { get; set; }

    public DateTime? CreatedDateTime { get; set; }

    public virtual Medal? Medal { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
