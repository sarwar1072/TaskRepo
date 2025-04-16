using Membership.Entities;
using Microsoft.AspNetCore.Identity;
using System;

namespace Membership.Seeds
{
	internal class ApplicationUserSeed
	{
		internal static ApplicationUser[] Users
		{
			get
			{
				var rootUser = new ApplicationUser
				{
					Id = Guid.Parse("e9b3be8c-99c5-42c7-8f2e-1eb39f6d9125"),
		  		    FullName = "Admin",
					UserName = "admin@gmail.com",
					NormalizedUserName = "ADMIN@GMAIL.COM",
					Email = "admin@gmail.com",
					NormalizedEmail = "ADMIN@GMAIL.COM",
					LockoutEnabled = true,
					EmailConfirmed = true
				};
				var normalUser = new ApplicationUser
				{
					Id = Guid.Parse( "8f3d96ce-76ec-4992-911a-33ceB81fa29d"),
					FullName = "sarwar",
					UserName = "sarwar@gmail.com",
					NormalizedUserName = "SARWAR@GMAIL.COM",
					Email = "sarwar@gmail.com",
					NormalizedEmail = "SARWAR@GMAIL.COM",
					LockoutEnabled = true,
					EmailConfirmed = true
				};
				var password = new PasswordHasher<ApplicationUser>();
				var rootHashed = password.HashPassword(rootUser, "Sarwar@1072");
				var normalHashed = password.HashPassword(normalUser, "Sarwar@1072");
                rootUser.PasswordHash = rootHashed;
				normalUser.PasswordHash = normalHashed;

				return new ApplicationUser[]
				{
                    rootUser,
					normalUser
                };
			}
		}
	}
}
