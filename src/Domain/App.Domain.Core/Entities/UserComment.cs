using System;
using System.Collections.Generic;

namespace App.Domain.Core.Entities;

public partial class UserComment
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public string? Comment { get; set; }

    public int ProductId { get; set; }

    public bool? ConfirmedByAdmin { get; set; }

    public int? CreatedByUserId { get; set; }

    public DateTime? CreatedDateTime { get; set; }

    public virtual Product Product { get; set; } = null!;
}
