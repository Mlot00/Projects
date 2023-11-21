using WebApplication2.Models.Domain;

namespace WebApplication2.Repositories.Interface
{
	public interface IContactRepository
	{
		Task<Contact> CreateAsync(Contact contact);

		Task<IEnumerable<Contact>> GetAllContactsAsync(); 

		Task<Contact?> GetByIdAsync(Guid id);

		Task<Contact?> UpdateContactAsync(Contact contact);

		Task<Contact?> DeleteContactAsync(Guid id);
	}
}
