﻿using FluentValidation;

namespace WebApi.Application.GenreOperations.Commands.UpdateGenre
{
	public class UpdateGenreCommandValidator : AbstractValidator<UpdateGenreCommand>
	{
		public UpdateGenreCommandValidator()
		{
			RuleFor(command => command.GenreId).GreaterThan(0);
			RuleFor(command => command.Model.Name).NotEmpty().MinimumLength(3);
		}
	}
}
