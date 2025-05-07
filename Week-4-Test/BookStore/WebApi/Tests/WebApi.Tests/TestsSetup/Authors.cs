using System;
using WebApi.DbOperations;
using WebApi.Entities;

namespace WebApi.Tests.TestsSetup
{
	public static class Authors
	{
		public static void AddAuthors(this BookStoreDbContext context)
		{
			context.Authors.AddRange(
				new Author
				{
					FirstName = "Eric",
					LastName = "Ries",
					BirthDate = new DateTime(1978, 09, 22)
				},
				new Author
				{
					FirstName = "Charlotte",
					LastName = "Perkins",
					BirthDate = new DateTime(1860, 07, 03)
				},
				new Author
				{
					FirstName = "Frank",
					LastName = "Herbert",
					BirthDate = new DateTime(1920, 10, 08)
				}
			);
		}
	}
}
