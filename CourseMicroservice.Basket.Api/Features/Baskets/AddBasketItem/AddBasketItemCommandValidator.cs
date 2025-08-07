using FluentValidation;

namespace CourseMicroservice.Basket.Api.Features.Baskets.AddBasketItem
{
    public class AddBasketItemCommandValidator : AbstractValidator<AddBasketItemCommand>
    {
        public AddBasketItemCommandValidator()
        {
            RuleFor(x => x.CourseId)
                .NotEmpty()
                .WithMessage("Course ID is required.");
            RuleFor(x => x.CourseName)
                .NotEmpty()
                .WithMessage("Course name is required.")
                .Length(4, 100)
                .WithMessage("Course name must between 4 and 100 chars.");
            RuleFor(x => x.CoursePrice)
                .GreaterThan(0)
                .WithMessage("Course price must be greater than zero.");
            RuleFor(x => x.ImageUrl)
                .MaximumLength(200)
                .WithMessage("Image URL must not exceed 200 characters.");
        }
    }
}
