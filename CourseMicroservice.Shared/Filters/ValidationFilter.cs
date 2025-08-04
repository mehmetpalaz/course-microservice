using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace CourseMicroservice.Shared.Filters
{
    public class ValidationFilter<T> : IEndpointFilter
    {
        public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
        {

            if (context.Arguments is null)
            {
                return await next(context);
            }

            var requestModel = context.Arguments!.FirstOrDefault(arg => arg is T);

            if(requestModel is null)
            {
                return await next(context);
            }

            var validator = context.HttpContext.RequestServices.GetService<IValidator<T>>();

            if(validator is null)
            {
                return await next(context);
            }

            var validationResult = await validator.ValidateAsync((T)requestModel);

            if (!validationResult.IsValid)
            {
                return Results.ValidationProblem(validationResult.ToDictionary());
            }

            return await next(context);
        }
    }
}
