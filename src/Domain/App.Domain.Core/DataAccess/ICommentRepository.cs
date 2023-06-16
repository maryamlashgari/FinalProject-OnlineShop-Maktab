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
        Task<List<UserCommentDetailDto>> GetAll();
        Task<UserCommentDetailDto> GetById(int id);
        Task<int> Create(UserComment comment);
        Task<int> Delete(UserComment comment);
    }
}
