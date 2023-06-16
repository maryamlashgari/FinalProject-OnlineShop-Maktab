using System;
using System.Collections.Generic;

namespace App.Domain.Core.Entities;

public partial class ProductFactor
{
    public int Id { get; set; }

    public int ProductId { get; set; }

    public int FactorId { get; set; }

    public int? CreatedByUserId { get; set; }

    public DateTime? CreatedDateTime { get; set; }
    public bool IsDeletedFlag { get; set; }

    public virtual Factor Factor { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
