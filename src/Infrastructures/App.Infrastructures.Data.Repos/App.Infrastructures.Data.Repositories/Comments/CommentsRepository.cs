using App.Domain.Core.DataAccess;
using App.Domain.Core.Dtos;
using App.Domain.Core.Entities;
using App.Infrastructures.Db.SqlServer.Ef.Database;
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

        public CommentsRepository(AppDBContext context)
        {
            _context = context;
        }

        public async Task<int> Create(UserComment comment)
        {
            await _context.AddAsync(comment);
            _context.SaveChanges();
            return comment.Id;
        }

        public async Task<int> Delete(UserComment comment)
        {
            var currentComment = _context.UserComments.FirstOrDefault(u => u.Id == comment.Id);
            currentComment.isde
        }

        public async Task<List<UserCommentDetailDto>> GetAll()
        {
             return await _context.UserComments.Select(u => new UserCommentDetailDto()
            {
                Id = u.Id,
                ProductId = u.ProductId,
                UserId = u.UserId,
                Comment = u.Comment,
                ConfirmedByAdmin = u.ConfirmedByAdmin
            }).ToListAsync();
        }

        public Task<UserCommentDetailDto> GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
