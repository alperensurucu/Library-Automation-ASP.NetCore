using FluentValidation;
using Library.Enum;

namespace Library.Models.FluentValidators
{
	public class BookValidator:AbstractValidator<Book>
	{
		public BookValidator()
		{
			RuleFor(x => x.Name).NotEmpty().NotNull().WithMessage("Zorunlu alan"
				).MaximumLength(15).WithMessage("Maksimum 15 karakter girebilirsiniz.");

		}
	}
}
