using App.Domain.Core.DataAccess;
using App.Domain.Core.Dtos;
using App.Domain.Core.Entities;
using App.Infrastructures.Db.SqlServer.Ef.Database;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructures.Data.Repositories.Comments
{
    public class CommentsRepository : ICommentRepository
    {
        private readonly AppDBContext _context;
        private readonly IMapper _mapper;


        public CommentsRepository(AppDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<int> Create(UserComment comment, CancellationToken cancellationToken)
        {
            //حواست باشه که به این مرحله که میرسه تاریخ ثبت رو در سرویس باید مشخص کرده باشی.
            await _context.AddAsync(comment, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return comment.Id;
        }

        public async Task<int> Delete(UserComment comment, CancellationToken cancellationToken)
        {
            var currentComment = await _context.UserComments.FirstOrDefaultAsync(u => u.Id == comment.Id && u.IsDeletedFlag != true, cancellationToken);
            if (currentComment != null)
            {
                currentComment.IsDeletedFlag = true;
                await _context.SaveChangesAsync(cancellationToken);
                return comment.Id;
            }
            else
            {
                throw new Exception("داده مورد نظر یافت نشد");
            }
        }

        public async Task<List<UserCommentDetailDto>> GetAll(CancellationToken cancellationToken)
        {
            //return await _context.UserComments.Select(u => new UserCommentDetailDto()
            //{
            //    Id = u.Id,
            //    ProductId = u.ProductId,
            //    UserId = u.UserId,
            //    Comment = u.Comment,
            //    ConfirmedByAdmin = u.ConfirmedByAdmin
            //}).ToListAsync();

            var comments = _mapper.Map<List<UserCommentDetailDto>>(await _context.UserComments.Where(c => c.IsDeletedFlag != true).ToListAsync(cancellationToken));
            return comments;

        }

        public async Task<UserCommentDetailDto> GetById(int id, CancellationToken cancellationToken)
        {
            if(id==0)
            {
                throw new ArgumentNullException(nameof(id));
            }
            var comment = _mapper.Map<UserCommentDetailDto>(await _context.UserComments.FirstOrDefaultAsync(c => c.Id == id && c.IsDeletedFlag != true, cancellationToken));
            //TODO: اینجا هم باید بپرسی که آیا اگر مقداری به ازای آیدی مورد نظر پیدا نشد بهتره چیکار کنیم. یا یااینکه جلوتر روش فکر کن و تصمیم بگیر
            return comment;
        }
    }
}
