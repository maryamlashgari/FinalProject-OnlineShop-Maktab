using System;
using System.Collections.Generic;

namespace App.Domain.Core.Entities;

public partial class Product
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public bool Status { get; set; }

    public int SellType { get; set; }

    public int BoothId { get; set; }

    public int Count { get; set; }

    public string ImageAddress { get; set; } = null!;

    public double Price { get; set; }

    public bool? ConfirmedByAdmin { get; set; }

    public int? CreatedByUserId { get; set; }

    public DateTime? CreatedDateTime { get; set; }
    public bool IsDeletedFlag { get; set; }

    public virtual ICollection<Auction> Auctions { get; set; } = new List<Auction>();

    public virtual Booth Booth { get; set; } = null!;

    public virtual ICollection<ProductFactor> ProductFactors { get; set; } = new List<ProductFactor>();

    public virtual ICollection<UserComment> UserComments { get; set; } = new List<UserComment>();
}
