using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.Models.Domain;
using WebApplication2.Repositories.Interface;

namespace WebApplication2.Repositories.Implementation
{
	public class CategoryRepository : ICategoryRepository
	{
		private readonly ApplicationDbContext _dbContext;
        public CategoryRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Category> CreateAsync(Category category)
		{
			await _dbContext.Categories.AddAsync(category);
			await _dbContext.SaveChangesAsync();
			return category;
		}

		public async Task<Category?> DeleteCategoryAsync(Guid id)
		{
			var categoryToDelete = await _dbContext.Categories.FirstOrDefaultAsync(c => c.Id == id);
			if (categoryToDelete != null)
			{
				_dbContext.Categories.Remove(categoryToDelete);
				await _dbContext.SaveChangesAsync();
				return categoryToDelete;
			}
			return null;

		}

		public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
		{
			return await _dbContext.Categories.ToListAsync();
		}

		public async Task<Category?> GetCategoryById(Guid id)
		{
			return await _dbContext.Categories.FirstOrDefaultAsync(temp => temp.Id == id);
		}

		public async Task<Category?> UpdateCategoryAsync(Category category)
		{
			 var existingCategory = await _dbContext.Categories.FirstOrDefaultAsync(temp => temp.Id == category.Id);
			if(existingCategory != null)
			{
				_dbContext.Categories.Entry(existingCategory).CurrentValues.SetValues(category);
				await _dbContext.SaveChangesAsync();
				return category;
			}
			return null;
		}
	}
}
