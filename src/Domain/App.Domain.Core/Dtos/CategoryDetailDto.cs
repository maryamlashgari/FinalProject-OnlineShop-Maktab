using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Dtos
{
    public class CategoryDetailDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public int? ParentId { get; set; }

        public string? Description { get; set; }

        public int? CreatedByUserId { get; set; }

        public DateTime? CreatedDateTime { get; set; }
        public bool IsDeletedFlag { get; set; }
    }
}
