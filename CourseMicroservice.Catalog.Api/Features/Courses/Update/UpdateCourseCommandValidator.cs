namespace CourseMicroservice.Catalog.Api.Features.Courses.Update
{
    public class UpdateCourseCommandValidator : AbstractValidator<UpdateCourseCommand>
    {
        public UpdateCourseCommandValidator() {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("The course name is required.")
                .MaximumLength(100)
                .WithMessage("The course name must not exceed 100 characters.");
            RuleFor(x => x.Description)
                .NotEmpty()
                .WithMessage("The course description is required.")
                .MaximumLength(500)
                .WithMessage("The course description must not exceed 500 characters.");
            RuleFor(x => x.Price)
                .GreaterThan(0)
                .WithMessage("The course price must be greater than zero.");
            RuleFor(x => x.CategoryId)
                .NotEmpty()
                .WithMessage("The category ID is required.");
        }
    }
}
