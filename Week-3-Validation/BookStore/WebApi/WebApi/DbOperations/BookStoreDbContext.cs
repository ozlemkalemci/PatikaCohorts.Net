using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace WebApi.DbOperations
{
	public class BookStoreDbContext : DbContext
	{
		public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options) : base(options)
		{
			
		}

		public DbSet<Book> Books { get; set; }
	}
}
