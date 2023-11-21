using WebApplication2.Models.Domain;

namespace WebApplication2.Repositories.Interface
{
	public interface ICategoryRepository
	{
		Task<Category> CreateAsync(Category category);

		Task<IEnumerable<Category>> GetAllCategoriesAsync();

		Task<Category?> GetCategoryById(Guid id);

		Task<Category?> UpdateCategoryAsync(Category category);

		Task<Category?> DeleteCategoryAsync(Guid id);
	}
}
