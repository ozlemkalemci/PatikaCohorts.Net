﻿using FluentValidation;

namespace WebApi.Application.AuthorOperations.Commands.UpdateAuthor
{
	public class UpdateAuthorCommandValidator : AbstractValidator<UpdateAuthorCommand>
	{
		public UpdateAuthorCommandValidator()
		{
			RuleFor(command => command.AuthorId).GreaterThan(0);
			RuleFor(command => command.Model.FirstName).NotEmpty().MinimumLength(2);
			RuleFor(command => command.Model.LastName).NotEmpty().MinimumLength(2);
			RuleFor(command => command.Model.BirthDate).NotEmpty().LessThan(System.DateTime.Now);
		}
	}
}
