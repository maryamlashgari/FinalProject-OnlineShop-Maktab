using App.Domain.Core.Dtos;
using App.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.DataAccess
{
    public interface ICommentRepository
    {
        Task<List<UserCommentDetailDto>> GetAll(CancellationToken cancellationToken);
        Task<UserCommentDetailDto> GetById(int id, CancellationToken cancellationToken);
        Task<int> Create(UserComment comment, CancellationToken cancellationToken);
        Task<int> Delete(UserComment comment, CancellationToken cancellationToken);
    }
}
