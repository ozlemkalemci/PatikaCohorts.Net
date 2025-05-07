using AutoMapper;
using WebApi.Application.AuthorOperations.Commands.CreateAuthor;
using WebApi.Application.AuthorOperations.Queries.GetAuthorDetail;
using WebApi.Application.AuthorOperations.Queries.GetAuthors;
using WebApi.Application.GenreOperations.Commands.CreateGenre;
using WebApi.Application.GenreOperations.Queries.GetGenres;
using WebApi.Entities;
using static WebApi.Application.BookOperations.Commands.CreateBook.CreateBookCommand;
using static WebApi.Application.BookOperations.Queries.GetBookDetail.GetBookDetailQuery;
using static WebApi.Application.BookOperations.Queries.GetBooks.GetBooksQuery;

namespace WebApi.Common
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			// 📘 Book ↔ ViewModel
			CreateMap<CreateBookModel, Book>();
			CreateMap<Book, BooksDetailViewModel>()
				.ForMember(dest => dest.Genre, opt => opt.MapFrom(src => ((GenreEnum)src.GenreId).ToString()));
			CreateMap<Book, BooksViewModel>()
				.ForMember(dest => dest.Genre, opt => opt.MapFrom(src => ((GenreEnum)src.GenreId).ToString()));

			// 📙 Genre ↔ ViewModel
			CreateMap<CreateGenreModel, Genre>();
			CreateMap<Genre, GenreViewModel>();

			// 📙 Author ↔ ViewModel
			CreateMap<CreateAuthorModel, Author>();
			CreateMap<Author, AuthorViewModel>()
	.ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FirstName + " " + src.LastName))
	.ForMember(dest => dest.BirthDate, opt => opt.MapFrom(src => src.BirthDate.ToString("yyyy-MM-dd")));

			CreateMap<Author, AuthorDetailViewModel>()
	.ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FirstName + " " + src.LastName))
	.ForMember(dest => dest.BirthDate, opt => opt.MapFrom(src => src.BirthDate.ToString("yyyy-MM-dd")));
		}
	}
}
