using System;
using System.Collections.Generic;

namespace App.Domain.Core.Entities;

public partial class FactorFinalDetail
{
    public int Id { get; set; }

    public int FactorId { get; set; }

    public double GeneralPrice { get; set; }

    public int BoothId { get; set; }

    public bool? IsPaid { get; set; }

    public int? CreatedByUserId { get; set; }

    public DateTime? CreatedDateTime { get; set; }

    public virtual Factor Factor { get; set; } = null!;
}
