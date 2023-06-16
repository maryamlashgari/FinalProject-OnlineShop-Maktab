using App.Domain.Core.Dtos;
using App.Domain.Core.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructures.Data.Repositories.AutoMapper
{
    public class AutoMapper_Infra:Profile
    {
        public AutoMapper_Infra()
        {
            CreateMap<UserComment, UserCommentDetailDto>().ReverseMap();
            CreateMap<Auction, AuctionDetailDto>().ReverseMap();
        }
    }
}
