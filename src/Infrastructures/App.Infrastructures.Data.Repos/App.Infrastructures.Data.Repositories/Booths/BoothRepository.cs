using App.Domain.Core.DataAccess;
using App.Domain.Core.Dtos;
using App.Domain.Core.Entities;
using App.Infrastructures.Data.Repositories.AutoMapper;
using App.Infrastructures.Db.SqlServer.Ef.Database;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructures.Data.Repositories.Booths
{
    public class BoothRepository : IBoothRepository
    {
        private readonly AppDBContext _context;
        private readonly Mapper _mapper;

        public BoothRepository(AppDBContext context, Mapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<int> Create(BoothDetailDto booth, CancellationToken cancellationToken)
        {
            if (booth == null)
            {
                throw new ArgumentNullException();
            }
            await _context.Booths.AddAsync(_mapper.Map<Booth>(booth), cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return booth.Id;
        }

        public async Task<int> Delete(int id, CancellationToken cancellationToken)
        {
            Booth? currentBooth = await _context.Booths.FirstOrDefaultAsync(b => b.Id == id && b.IsDeletedFlag != true, cancellationToken: cancellationToken);
            if (currentBooth == null)
            {
                throw new Exception("داده مورد نظر یافت نشد.");
            }
            currentBooth.IsDeletedFlag = true;
            return id;
        }

        public async Task<List<BoothDetailDto>> GetAll(CancellationToken cancellationToken)
        {
            List<Booth> result = await _context.Booths.ToListAsync();
            return _mapper.Map<List<BoothDetailDto>>(result);
        }

        public async Task<List<BoothDetailDto>> GetAllByUserId(int userId, CancellationToken cancellationToken)
        {
            if (userId == 0)
            {
                throw new ArgumentNullException();
            }
            List<Booth> result = await _context.Booths.Where(b => b.UserId == userId).ToListAsync();
            return _mapper.Map<List<BoothDetailDto>>(result);
        }

        public async Task<BoothDetailDto> GetById(int id, CancellationToken cancellationToken)
        {
            if (id == 0)
            {
                throw new ArgumentNullException();
            }
            var result = await _context.Booths.FirstOrDefaultAsync(b => b.Id == id);
            return _mapper.Map<BoothDetailDto>(result);
        }

        public async Task<int> Update(BoothDetailDto booth, CancellationToken cancellationToken)
        {
            if (booth == null)
            {
                throw new ArgumentNullException();
            }
            var currentBooth = await _context.Booths.FirstOrDefaultAsync(b => b.Id == booth.Id);
            if (currentBooth == null)
            {
                throw new Exception("داده مورد نظر یافت نشد");
            }
            currentBooth.MedalId = booth.MedalId;
            currentBooth.CathIdsCsv = booth.CathIdsCsv;
            currentBooth.Name = booth.Name;
            await _context.SaveChangesAsync();
            return currentBooth.Id;
        }
    }
}
