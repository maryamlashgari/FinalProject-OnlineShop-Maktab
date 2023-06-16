using System;
using System.Collections.Generic;

namespace App.Domain.Core.Entities;

public partial class Auction
{
    public int Id { get; set; }

    public int ProductId { get; set; }

    public DateTime DateTimeFrom { get; set; }

    public DateTime DateTimeTo { get; set; }

    public double? BestPriceOffer { get; set; }

    public bool? FinishedFlag { get; set; }
    public bool IsDeletedFlag { get; set; }

    public int? CreatedByUserId { get; set; }

    public DateTime? CreatedDateTime { get; set; }

    public virtual ICollection<Offer> Offers { get; set; } = new List<Offer>();

    public virtual Product Product { get; set; } = null!;
}
