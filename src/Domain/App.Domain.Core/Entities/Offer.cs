using System;
using System.Collections.Generic;

namespace App.Domain.Core.Entities;

public partial class Offer
{
    public int Id { get; set; }

    public int AuctionId { get; set; }

    public int UserId { get; set; }

    public double SuggestedPrice { get; set; }

    public DateTime? SuggestionDateTime { get; set; }

    public bool? IsSuccessFlag { get; set; }

    public int? CreatedByUserId { get; set; }

    public DateTime? CreatedDateTime { get; set; }
    public bool IsDeletedFlag { get; set; }

    public virtual Auction Auction { get; set; } = null!;
}
