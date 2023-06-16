using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Dtos
{
    public class AuctionDetailDto
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
    }
}
