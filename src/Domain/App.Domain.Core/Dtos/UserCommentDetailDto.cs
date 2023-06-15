﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Dtos
{
    public class UserCommentDetailDto
    {
        public int Id { get; set; }

        public int? UserId { get; set; }

        public string? Comment { get; set; }

        public int ProductId { get; set; }

        public bool? ConfirmedByAdmin { get; set; }
    }
}
