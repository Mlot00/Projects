using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.Models.Domain;
using WebApplication2.Repositories.Interface;

namespace WebApplication2.Repositories.Implementation
{
	public class ContactRepository : IContactRepository
	{
		private readonly ApplicationDbContext _dbContext;

		public ContactRepository(ApplicationDbContext dbContext)
        {
			_dbContext = dbContext;
		}

        public async Task<Contact> CreateAsync(Contact contact)
		{
			await _dbContext.Contacts.AddAsync(contact);
			await _dbContext.SaveChangesAsync();
			return contact;
		}

		public async Task<Contact?> DeleteContactAsync(Guid id)
		{
			var existingContact = await _dbContext.Contacts.FirstOrDefaultAsync(x => x.Id == id);
			if (existingContact== null)
			{
				return null;
			}
			_dbContext.Contacts.Remove(existingContact);
			await _dbContext.SaveChangesAsync();
			return existingContact;
		}

		public async Task<IEnumerable<Contact>> GetAllContactsAsync()
		{
			//Return all contacts include relationship with category
			return await _dbContext.Contacts.Include(x=>x.CategoryOption).ToListAsync();
		}

		public async Task<Contact?> GetByIdAsync(Guid id)
		{
			return await _dbContext.Contacts.Include(x=> x.CategoryOption).FirstOrDefaultAsync(x => x.Id == id);
		}

		public async Task<Contact?> UpdateContactAsync(Contact contact)
		{
			var existiongContact = await _dbContext.Contacts.Include(p=>p.CategoryOption).FirstOrDefaultAsync(x=> x.Id == contact.Id);
			if (existiongContact == null)
			{
				return null;
			}

			//update contact
			_dbContext.Contacts.Entry(existiongContact).CurrentValues.SetValues(contact);

			existiongContact.CategoryOption = contact.CategoryOption;

			await _dbContext.SaveChangesAsync();

			return contact;
		}
	}
}
