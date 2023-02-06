using BestPractice.Api.Models;
using FluentValidation;

namespace BestPractice.Api.Validation
{
    public class ContactValidator : AbstractValidator<ContactDVO>
    {
        public ContactValidator()
        {
            RuleFor(i => i.FullName).NotEmpty().WithMessage("İsim soy isim boş olamaz");
            RuleFor(x => x.Id).LessThan(100).WithMessage("Id 100'den büyük olamaz");
        }
    }
}
