using FluentValidation;

namespace CourseMicroservice.Catalog.Api.Features.Categories.Create
{
    public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
    {
        public CreateCategoryCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.")
                .Length(4, 100).WithMessage("Name must be between 4 and 100 characters.");
        }
    }
}
