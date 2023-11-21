using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace WebApplication2.Data
{
	public class AuthDbContext : IdentityDbContext
	{
		public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);

			var readerRoleId = "a9965675-7f3f-4b3e-8b69-f1c18fc14057";
			var writerRoleId = "26201f24-6479-4b79-8509-f985a629e7cf";

			//Creaate Reader and Writer Role
			var roles = new List<IdentityRole>
			{
				new IdentityRole()
				{
					Id = readerRoleId,
					Name = "Reader",
					NormalizedName = "Reader".ToUpper(),
					ConcurrencyStamp = readerRoleId
				},
				new IdentityRole()
				{
					Id= writerRoleId,
					Name = "Writer",
					NormalizedName = "Writer".ToUpper(),
					ConcurrencyStamp= writerRoleId
				}
			};

			//Seed the roles
			builder.Entity<IdentityRole>().HasData(roles);

			//Create an admin user
			var adminUserId = "ff0a3f4f-ca9e-47d7-b4d9-fea72f647339";
			var admin = new IdentityUser()
			{
				Id = adminUserId,
				UserName = "admin@webapp.com",
				Email = "admin@webapp.com",
				NormalizedEmail = "admin@webapp.com".ToUpper(),
				NormalizedUserName = "admin@webapp.com".ToUpper()
			};

			admin.PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(admin, "Admin@123");
			builder.Entity<IdentityUser>().HasData(admin);

			//give roles to admin
			var adminRoles = new List<IdentityUserRole<string>>()
			{
				new()
				{
					UserId = adminUserId,
					RoleId = readerRoleId
				},
				new()
				{
					UserId = adminUserId,
					RoleId = writerRoleId
				}
			};

			builder.Entity<IdentityUserRole<string>>().HasData(adminRoles);

			//Create a normal user
			var normalUserId = "857f538b-8a44-4d46-ad57-53578bddda08";
			var normalUser = new IdentityUser()
			{
				Id = normalUserId,
				UserName = "user2@webapp.com",
				Email = "user2@webapp.com",
				NormalizedEmail = "user2@webapp.com".ToUpper(),
				NormalizedUserName = "user2@webapp.com".ToUpper()
			};

			normalUser.PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(admin, "User2@123");
			builder.Entity<IdentityUser>().HasData(normalUser);

			//give roles to normal user
			var normalUserRoles = new List<IdentityUserRole<string>>()
			{
				new()
				{
					UserId = normalUserId,
					RoleId = readerRoleId
				},

			};

			builder.Entity<IdentityUserRole<string>>().HasData(normalUserRoles);
		}


	}
}
