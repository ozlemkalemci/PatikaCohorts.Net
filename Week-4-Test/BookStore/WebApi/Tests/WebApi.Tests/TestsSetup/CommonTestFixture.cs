﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Common;
using WebApi.DbOperations;

namespace WebApi.Tests.TestsSetup
{
	public class CommonTestFixture
	{
		public  BookStoreDbContext Context { get; set; }
		public IMapper Mapper { get; set; }
		public CommonTestFixture()
		{
			var options = new DbContextOptionsBuilder<BookStoreDbContext>().UseInMemoryDatabase(databaseName: "BookStoreTestDb").Options;
			Context = new BookStoreDbContext(options);
			Context.Database.EnsureCreated();

			Context.AddGenres();
			Context.AddAuthors();
			Context.AddBooks();
			Context.SaveChanges();

			Mapper = new MapperConfiguration(cfg => { cfg.AddProfile<MappingProfile>(); }).CreateMapper();

		}
	}
}
