using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CRJ_Shop.Data
{
	public class IdentityDbContext : IdentityDbContext<IdentityUser>
	{
		public IdentityDbContext(DbContextOptions<IdentityDbContext> options)
			: base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);

			string adminRoleId = Guid.NewGuid().ToString();
			string userRoleId = Guid.NewGuid().ToString();
			string adminUserId = Guid.NewGuid().ToString();

			// Seed roles
			builder.Entity<IdentityRole>().HasData(
				new IdentityRole { Id = adminRoleId, Name = "Admin", NormalizedName = "ADMIN" },
				new IdentityRole { Id = userRoleId, Name = "User", NormalizedName = "USER" }
			);

			// create an admin user with the password "password"
			var hasher = new PasswordHasher<IdentityUser>();
			var adminUser = new IdentityUser
			{
				Id = adminUserId,
				UserName = "admin@test.com",
				PasswordHash = hasher.HashPassword(null, "password")
			};

			// inserts the admin user
			builder.Entity<IdentityUser>().HasData(adminUser);

			// assign the admin role to the admin user
			builder.Entity<IdentityUserRole<string>>().HasData(
				new IdentityUserRole<string> { UserId = adminUserId, RoleId = adminRoleId }
			);
		}
	}
}
