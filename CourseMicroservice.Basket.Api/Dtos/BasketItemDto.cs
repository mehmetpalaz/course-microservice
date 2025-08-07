namespace CourseMicroservice.Basket.Api.Dtos
{
    public record BasketItemDto(Guid CourseId, string CourseName, string? ImageUrl, decimal CoursePrice, decimal? CoursePriceByApplyDiscount);
}
