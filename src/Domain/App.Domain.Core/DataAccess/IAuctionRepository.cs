using App.Domain.Core.Dtos;
using App.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.DataAccess
{
    public interface IAuctionRepository
    {
        Task<List<AuctionDetailDto>> GetAll(CancellationToken cancellationToken);
        Task<List<AuctionDetailDto>> GetAllByUserId(int userId, CancellationToken cancellationToken);
        Task<AuctionDetailDto> GetById(int id, CancellationToken cancellationToken);
        Task<int> Create(Auction auction, CancellationToken cancellationToken);
        Task<int> Update(AuctionDetailDto auctionDetail, CancellationToken cancellationToken);
        Task<int> Delete(Auction auction, CancellationToken cancellationToken);
    }
}
