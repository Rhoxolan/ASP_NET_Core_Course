﻿using Microsoft.AspNetCore.Identity;

namespace OnlineShop.Data
{
	public class User : IdentityUser
	{
		public int YearOfBirth { get; set; }
	}
}
