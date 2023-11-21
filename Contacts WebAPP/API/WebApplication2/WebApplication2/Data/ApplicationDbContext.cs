using Microsoft.EntityFrameworkCore;
using WebApplication2.Models.Domain;

namespace WebApplication2.Data
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
		{
			
		}

		public DbSet<Contact> Contacts { get; set; }
		public DbSet<Category> Categories { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);


			//Making Email as unique property
			modelBuilder.Entity<Contact>().HasIndex(c => c.Email).IsUnique();

			modelBuilder.Entity<Category>().ToTable("Categories");

			modelBuilder.Entity<Category>().HasData(new Category { Id = Guid.NewGuid(), Name = "Prywatny" });
			modelBuilder.Entity<Category>().HasData(new Category { Id = Guid.NewGuid(), Name = "Służbowy" });
			modelBuilder.Entity<Category>().HasData(new Category { Id = Guid.NewGuid(), Name = "Inny" });
		}

	}
}
