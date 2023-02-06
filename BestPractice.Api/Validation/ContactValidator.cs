using BestPractice.Api.Models;
using FluentValidation;

namespace BestPractice.Api.Validation
{
    public class ContactValidator : AbstractValidator<ContactDVO>
    {
        public ContactValidator()
        {
            RuleFor(x => x.Id).GreaterThan(100).WithMessage("Id 100'den büyük olamaz");
        }
    }
}
