using Azure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models.Domain;
using WebApplication2.Models.DTO;
using WebApplication2.Repositories.Implementation;
using WebApplication2.Repositories.Interface;

namespace WebApplication2.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ContactsController : ControllerBase
	{
		private readonly IContactRepository _contactRepository;
		private readonly ICategoryRepository _categoryRepository;

		public ContactsController(IContactRepository contactRepository, ICategoryRepository categoryRepository)
		{
			_contactRepository = contactRepository;
			_categoryRepository = categoryRepository;
		}

		// POST: {apibaseurl}/api/contacts
		[HttpPost]
		[Authorize(Roles = "Reader")]
		public async Task<IActionResult> CreateContact([FromBody] CreateContactRequest request)
		{
			//Convert DTO to Domain
			var contact = new Contact()
			{
				FirstName = request.FirstName,
				LastName = request.LastName,
				Email = request.Email,
				Phone = request.Phone,
				DateOfBirth = request.DateOfBirth,
				CategoryOption = new Category()
			};

			//Adding real Category by categoryId to the Contact
			var existingCategory =  await _categoryRepository.GetCategoryById(request.Category);
			if (existingCategory != null)
            {
				contact.CategoryOption = existingCategory;
            }

            var ContactrReturn = await _contactRepository.CreateAsync(contact);

			//Convert Domain Model back to DTO
			var resposne = new ContactResposne()
			{
				Id = ContactrReturn.Id,
				FirstName = ContactrReturn.FirstName,
				LastName = ContactrReturn.LastName,
				Email = ContactrReturn.Email,
				Phone = ContactrReturn.Phone,
				DateOfBirth = ContactrReturn.DateOfBirth,
				CategoryOption = new Category() { Id = ContactrReturn.CategoryOption.Id, Name=ContactrReturn.CategoryOption.Name }
			};

			return Ok(resposne);
		}


		//GET: {apibaseurl}/api/contacts
		[HttpGet]
		public async Task<IActionResult> GetAllContact()
		{
			var contacts = await _contactRepository.GetAllContactsAsync();

			// Convert Domain model to DTO
			var resposne = new List<ContactResposne>();
			foreach (var contact in contacts)
			{
				resposne.Add(new ContactResposne()
				{
					Id= contact.Id,
					FirstName = contact.FirstName,
					LastName = contact.LastName,
					Email = contact.Email,
					Phone = contact.Phone,
					DateOfBirth = contact.DateOfBirth,
					CategoryOption= contact.CategoryOption,
				});
			}

			return Ok(resposne);
		}

		//GET: {apibaseurl}/api/contacts/{id}
		[HttpGet]
		[Route("{id:Guid}")]
		public async Task<IActionResult> GetContactById([FromRoute] Guid id)
		{
			// get contact from repo
			var contact= await _contactRepository.GetByIdAsync(id);
			if(contact==null)
				return NotFound();

			//convert domain model to dto 
			 var resposne =new ContactResposne()
			{
				Id = contact.Id,
				FirstName = contact.FirstName,
				LastName = contact.LastName,
				Email = contact.Email,
				Phone = contact.Phone,
				DateOfBirth = contact.DateOfBirth,
				CategoryOption = contact.CategoryOption,
			};

			return Ok(resposne);

		}

		//PUT: {apibaseurl}/api/contacts/{id}
		[HttpPut]
		[Route("{id:Guid}")]
		[Authorize(Roles = "Reader")]
		public async Task<IActionResult> UpdateContactById([FromRoute]Guid id, ContactUpdate request)
		{
			//convert DTO to domain model
			var contact = new Contact()
			{
				Id = id,
				FirstName = request.FirstName,
				LastName = request.LastName,
				Email = request.Email,
				Phone = request.Phone,
				DateOfBirth = request.DateOfBirth,
				CategoryOption = new Category()
			};

			var existingCategory = await _categoryRepository.GetCategoryById(request.Category);
			if(existingCategory!=null)
			{
				contact.CategoryOption = existingCategory;
			}

			//call repository to update contact domain model
			var updateddContat =await _contactRepository.UpdateContactAsync(contact);
			if(updateddContat==null)
				return NotFound();

			//conver domain model back to dto
			var resposne = new ContactResposne()
			{
				Id = updateddContat.Id,
				FirstName = updateddContat.FirstName,
				LastName = updateddContat.LastName,
				Email = updateddContat.Email,
				Phone = updateddContat.Phone,
				DateOfBirth = updateddContat.DateOfBirth,
				CategoryOption = updateddContat.CategoryOption,
			};
			return Ok(resposne);
		}

		//DELETE: {apibaseurl}/api/contacts/{id}
		[HttpDelete]
		[Route("{id:Guid}")]
		[Authorize(Roles = "Reader")]
		public async Task<IActionResult> DeleteContact ([FromRoute]Guid id)
		{
			var deletedContact = await _contactRepository.DeleteContactAsync(id);
			if(deletedContact == null)
			{
				return NotFound();
			}

			var resposne = new ContactResposne()
			{
				Id = deletedContact.Id,
				FirstName = deletedContact.FirstName,
				LastName = deletedContact.LastName,
				Email = deletedContact.Email,
				Phone = deletedContact.Phone,
				DateOfBirth = deletedContact.DateOfBirth,
				CategoryOption = deletedContact.CategoryOption,
			};
			return Ok(resposne);
		}
	}
}
