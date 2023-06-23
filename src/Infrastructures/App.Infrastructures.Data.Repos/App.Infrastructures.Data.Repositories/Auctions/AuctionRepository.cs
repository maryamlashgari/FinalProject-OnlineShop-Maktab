using App.Domain.Core.DataAccess;
using App.Domain.Core.Dtos;
using App.Domain.Core.Entities;
using App.Infrastructures.Db.SqlServer.Ef.Database;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructures.Data.Repositories.Auctions
{
    public class AuctionRepository : IAuctionRepository
    {
        private readonly AppDBContext _context;
        private readonly Mapper _mapper;

        public AuctionRepository(AppDBContext context, Mapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<int> Create(Auction auction, CancellationToken cancellationToken)
        {
            //حواست باشه که به این مرحله که میرسه تاریخ ثبت رو در سرویس باید مشخص کرده باشی.
            if (auction == null)
            {
                throw new ArgumentNullException(nameof(auction));
            }
            await _context.AddAsync(auction, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return auction.Id;
        }

        public async Task<int> Delete(Auction auction, CancellationToken cancellationToken)
        {
            if(auction == null)
            {
                throw new ArgumentNullException(nameof(auction));
            }

            var currentAuction = _mapper.Map<Auction>(await _context.Auctions.FirstOrDefaultAsync(a => a.Id == auction.Id, cancellationToken));
            if (currentAuction != null)
            {
                currentAuction.IsDeletedFlag = true;
                await _context.SaveChangesAsync(cancellationToken);
                return currentAuction.Id;
            }
            else
            {
                throw new Exception("داده مورد نظر یافت نشد");
            }
        }

        public async Task<List<AuctionDetailDto>> GetAll(CancellationToken cancellationToken)
        {
            var auctions = await _context.Auctions.Where(a => a.IsDeletedFlag != true).ToListAsync(cancellationToken);
            if (auctions != null && auctions.Count() > 0)
            {
                return _mapper.Map<List<AuctionDetailDto>>(auctions);
            }
            throw new Exception("داده مورد نظر یافت نشد.");

        }

        public async Task<List<AuctionDetailDto>> GetAllByUserId(int userId, CancellationToken cancellationToken)
        {
            if (userId == 0)
            {
                throw new ArgumentNullException(nameof(userId));
            }

            var currentUsersAuctions = await _context.Auctions.Where(a => a.CreatedByUserId == userId && a.IsDeletedFlag != true).ToListAsync(cancellationToken);
            if (currentUsersAuctions != null && currentUsersAuctions.Count() > 0)
            {
                return _mapper.Map<List<AuctionDetailDto>>(currentUsersAuctions);
            }
            else
            {
                throw new Exception("داده مورد نظر یافت نشد");
            }
        }

        public async Task<AuctionDetailDto> GetById(int id, CancellationToken cancellationToken)
        {
            if (id == 0)
            {
                throw new ArgumentNullException(nameof(id));
            }
            var result = await _context.Auctions.FirstOrDefaultAsync(a => a.Id == id, cancellationToken);
            if (result != null)
            {
                return _mapper.Map<AuctionDetailDto>(result);
            }
            else
            {
                throw new Exception("داده مورد نظر یافت نشد");
            }
        }

        public async Task<int> Update(AuctionDetailDto auctionDetail, CancellationToken cancellationToken)
        {
            if (auctionDetail == null)
            {
                throw new ArgumentNullException(nameof(auctionDetail));
            }

            var currentAuction = await _context.Auctions.FirstOrDefaultAsync(a => a.Id == auctionDetail.Id, cancellationToken);
            if (currentAuction != null)
            {
                currentAuction.Id = auctionDetail.Id;
                currentAuction.ProductId = auctionDetail.ProductId;
                currentAuction.DateTimeFrom = auctionDetail.DateTimeFrom;
                currentAuction.DateTimeTo = auctionDetail.DateTimeTo;
                await _context.SaveChangesAsync(cancellationToken);
                return currentAuction.Id;
            }
            else
            {
                throw new Exception("داده مورد نظر یافت نشد.");
            }
        }
    }
}
