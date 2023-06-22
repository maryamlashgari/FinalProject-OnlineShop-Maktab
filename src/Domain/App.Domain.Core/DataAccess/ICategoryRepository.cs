using App.Domain.Core.Dtos;
using App.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.DataAccess
{
    public interface ICategoryRepository
    {
        Task<List<CategoryDetailDto>> GetAll(CancellationToken cancellation);
        Task<CategoryDetailDto> GetById(int id, CancellationToken cancellation);
        Task<int> Create(Category category, CancellationToken cancellation);
        Task<int> Update(Category category, CancellationToken cancellation);
        Task Delete(int id, CancellationToken cancellation);
    }
}
