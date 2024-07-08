using Book_Library_Manager.Core.Models.DTOs;
using FluentValidation;

namespace Book_Library_Manager.Core.Validations;

public class BookValidator : AbstractValidator<BookDto>
{
    public BookValidator()
    {
        RuleFor(x => x.Title).NotEmpty().MaximumLength(200);
        RuleFor(x => x.Author).NotEmpty().MaximumLength(100);
        RuleFor(x => x.ISBN).NotEmpty().Matches(@"^(?:ISBN(?:-1[03])?:? )?(?=[0-9X]{10}$|(?=(?:[0-9]+[- ]){3})[- 0-9X]{13}$|97[89][0-9]{10}$|(?=(?:[0-9]+[- ]){4})[- 0-9]{17}$)(?:97[89][- ]?)?[0-9]{1,5}[- ]?[0-9]+[- ]?[0-9]+[- ]?[0-9X]$");
        RuleFor(x => x.PublicationYear).InclusiveBetween(1000, DateTime.Now.Year);
        RuleFor(x => x.Genre).NotEmpty().MaximumLength(50);
        RuleFor(x => x.ReadingProgress).InclusiveBetween(0, 100);
    }
}
