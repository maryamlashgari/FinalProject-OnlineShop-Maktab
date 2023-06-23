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

namespace App.Infrastructures.Data.Repositories.Categories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDBContext _context;

        public CategoryRepository(AppDBContext context)
        {
            _context = context;
        }
        public async Task<int> Create(Category category, CancellationToken cancellationTocken)
        {
            if (category == null)
            {
                throw new ArgumentNullException("category");
            }
            await _context.AddAsync(category,cancellationTocken);
            await _context.SaveChangesAsync(cancellationTocken);
            return category.Id;
        }

        public async Task Delete(int id, CancellationToken cancellationTocken)
        {
            if (id == 0)
            {
                throw new ArgumentNullException("id");
            }
            var currentCategory = await _context.Categories.FirstOrDefaultAsync(c => c.Id == id && c.IsDeletedFlag != true, cancellationTocken);
            if (currentCategory == null)
            {
                throw new Exception("داده مورد نظر یافت نشد");
            }
            currentCategory.IsDeletedFlag = true;
            await _context.SaveChangesAsync(cancellationTocken);
        }

        public async Task<List<CategoryDetailDto>> GetAll(CancellationToken cancellationTocken)
        {
            List<Category> list = await _context.Categories.Where(c=>c.IsDeletedFlag != true).ToListAsync(cancellationTocken);
            if (list != null && list.Count() > 0)
            {
                List<CategoryDetailDto> result = new List<CategoryDetailDto>();
                foreach (var item in list)
                {
                    result.Add(ConvertCategoryEntityToCategoryDetailDto(item));
                }
                return result;
            }
            return null;//باید تصمیم بگیرم که در صورت خالی بودن نال برگردانم یا اکسپشن
        }

        public async Task<CategoryDetailDto> GetById(int id, CancellationToken cancellationTocken)
        {
            if (id == 0)
            {
                throw new ArgumentNullException("id");
            }
            var currentCategory = await _context.Categories.FirstOrDefaultAsync(c => c.Id == id && c.IsDeletedFlag != true,cancellationTocken);
            if (currentCategory == null)
            {
                throw new Exception("داده مورد نظر یافت نشد");
            }
            return ConvertCategoryEntityToCategoryDetailDto(currentCategory);

        }

        public async Task<int> Update(Category category, CancellationToken cancellationTocken)
        {
            if (category == null)
            {
                throw new ArgumentNullException("category");
            }
            var currentCategory =await _context.Categories.FirstOrDefaultAsync(c => c.Id == category.Id && c.IsDeletedFlag != true,cancellationTocken);
            if (currentCategory != null)
            {
                currentCategory.Name = category.Name;
                currentCategory.ParentId = category.ParentId;
                currentCategory.Description = category.Description;
            }
            throw new Exception("داده مورد نظر یافت نشد");
        }

        public static CategoryDetailDto ConvertCategoryEntityToCategoryDetailDto(Category category)
        {
            CategoryDetailDto dto = new CategoryDetailDto()
            {
                Id = category.Id,
                Name = category.Name,
                ParentId = category.ParentId,
                CreatedByUserId = category.CreatedByUserId,
                CreatedDateTime = category.CreatedDateTime,
                Description = category.Description,
                IsDeletedFlag = category.IsDeletedFlag,
            };
            return dto;
        }
    }
}
