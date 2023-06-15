using App.Domain.Core.DataAccess;
using App.Domain.Core.Dtos;
using App.Domain.Core.Entities;
using App.Infrastructures.Db.SqlServer.Ef.Database;
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
        public List<UserCommentDetailDto> GetAllUserComments()
        {
            return _context.UserComments.Select(u => new UserCommentDetailDto()
            {
                Id = u.Id,
                ProductId = u.ProductId,
                UserId = u.UserId,
                Comment = u.Comment,
                ConfirmedByAdmin = u.ConfirmedByAdmin
            }).ToList();
        }
    }
}
