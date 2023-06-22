using App.Domain.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.DataAccess
{
    public interface IBoothRepository
    {
        Task<List<BoothDetailDto>> GetAll(CancellationToken cancellationToken);
        Task<List<BoothDetailDto>> GetAllByUserId(int userId, CancellationToken cancellationToken);
        Task<BoothDetailDto> GetById(int id, CancellationToken cancellationToken);
        Task<int> Create(BoothDetailDto booth, CancellationToken cancellationToken);
        Task<int> Update(BoothDetailDto booth, CancellationToken cancellationToken);
        Task<int> Delete(int id, CancellationToken cancellationToken);
    }
}
