using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Data;
using WebApplication2.Models.Domain;
using WebApplication2.Models.DTO;
using WebApplication2.Repositories.Implementation;
using WebApplication2.Repositories.Interface;


namespace WebApplication2.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CategoriesController : ControllerBase
	{
		private readonly ICategoryRepository _categoryRepository;

		public CategoriesController(ICategoryRepository categoryRepository)
		{
			_categoryRepository = categoryRepository;
		}

		[HttpPost]
		[Authorize(Roles = "Writer")]
		public async Task<IActionResult> CreateCategory(CreateCategoryRequest request)
		{
			//Convert DTO to Domain
			var category = new Category
			{
				Name = request.Name,
			};

			await _categoryRepository.CreateAsync(category);

			//Convert Domain to DTO
			var response = new CategoryResponse
			{
				Id = category.Id,
				Name = request.Name
			};

			return Ok(response);
		}


		// GET: https://localhost:7178/api/Categories
		[HttpGet]
		public async Task<IActionResult> GetAllCategories()
		{
			var categories = await _categoryRepository.GetAllCategoriesAsync();

			//Map Domain model to DTO
			var response = new List<CategoryResponse>();
			foreach (var category in categories)
			{
				var categoryResponse = new CategoryResponse { Id = category.Id, Name = category.Name };
				response.Add(categoryResponse);
			}

			return Ok(response);
		}


		// GET: https://localhost:7178/api/Categories/{id}
		[HttpGet]
		[Route("{Id}")]
		public async Task<IActionResult> GetCategoryByID([FromRoute] Guid Id)
		{
			var existingCategory = await _categoryRepository.GetCategoryById(Id);

			if(existingCategory == null)
			{
				return NotFound("Category not foud. Id is invalid");
			}

			var resposne = new CategoryResponse()
			{
				Id = existingCategory.Id,
				Name = existingCategory.Name,
			};

			return Ok(resposne);
		}


		//PUT: https://localhost:7178/api/Categories/{id}
		[HttpPut]
		[Route("{Id}")]
		[Authorize(Roles = "Writer")]
		public async Task<IActionResult> UpdateCategory([FromRoute] Guid Id, CategoryUpdate updateRequest)
		{
			//Convert DTo to Domain
			var category = new Category()
			{
				Id = Id,
				Name = updateRequest.Name,
			};

			var updatedCategory = await _categoryRepository.UpdateCategoryAsync(category);

			if (updatedCategory == null)
				return NotFound();

			//Convert Domain To DTO
			var response = new CategoryResponse()
			{
				Id = updatedCategory.Id,
				Name = updatedCategory.Name,
			};
			return Ok(response);
		}


		//DELETE: https://localhost:7178/api/Categories/{id}
		[HttpDelete]
		[Route("{Id}")]
		[Authorize(Roles = "Writer")]
		public async Task<IActionResult> DeleteCategory(Guid Id)
		{
			var category = await _categoryRepository.DeleteCategoryAsync(Id);

			if(category == null)
				return NotFound();

			var response = new CategoryResponse()
			{
				Id = category.Id,
				Name = category.Name,
			};

			return Ok(response);
		}
	}
}
