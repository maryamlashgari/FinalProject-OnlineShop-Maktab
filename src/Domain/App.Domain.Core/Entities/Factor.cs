using System;
using System.Collections.Generic;

namespace App.Domain.Core.Entities;

public partial class Factor
{
    public int Id { get; set; }

    public int ProductId { get; set; }

    public int Count { get; set; }

    public int? UserId { get; set; }

    public int? CreatedByUserId { get; set; }

    public DateTime? CreatedDateTime { get; set; }

    public virtual ICollection<FactorFinalDetail> FactorFinalDetails { get; set; } = new List<FactorFinalDetail>();

    public virtual ICollection<ProductFactor> ProductFactors { get; set; } = new List<ProductFactor>();
}
