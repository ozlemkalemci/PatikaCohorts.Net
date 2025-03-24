using FluentValidation;
using PatikaPaparaBootcamp.Domain.Entities;
namespace PatikaPaparaBootcamp.Application.Validations
{
	public class ClientValidator : AbstractValidator<Client>
	{
		public ClientValidator()
		{
			RuleFor(c => c.Name).NotEmpty().WithMessage("Name is required");
			RuleFor(c => c.SurName).NotEmpty().WithMessage("Name is required");
			RuleFor(c => c.Email).NotEmpty().EmailAddress().WithMessage("Valid email is required");
			RuleFor(c => c.Phone).NotEmpty().Matches(@"^\d{10}$").WithMessage("Invalid phone number");
			RuleFor(c => c.Address).NotEmpty().WithMessage("Address is required");
		}
	}
}
