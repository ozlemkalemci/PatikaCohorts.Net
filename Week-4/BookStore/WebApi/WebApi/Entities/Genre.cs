using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace WebApi.Entities
{
	public class Genre
	{
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		public string Name { get; set; }
		public bool IsActive { get; set; } = true;
	}
}
