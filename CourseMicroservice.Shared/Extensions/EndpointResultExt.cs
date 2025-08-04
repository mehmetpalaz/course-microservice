using Microsoft.AspNetCore.Http;
using System.Net;

namespace CourseMicroservice.Shared.Extensions
{
    public static class EndpointResultExt
    {
        public static IResult ToEndpointResult<T>(this ServiceResult<T> result)
        {
            return result.Status switch
            {
                HttpStatusCode.OK => Results.Ok(result),
                HttpStatusCode.Created => Results.Created(result.UrlAsCreated, result),
                HttpStatusCode.NoContent => Results.NoContent(),
                HttpStatusCode.BadRequest => Results.BadRequest(result.Fail),
                HttpStatusCode.NotFound => Results.NotFound(result.Fail),
                _ => Results.BadRequest(result.Fail)
            };

        }
        public static IResult ToEndpointResult(this ServiceResult result)
        {
            return result.Status switch
            {
                HttpStatusCode.NoContent => Results.NoContent(),
                HttpStatusCode.BadRequest => Results.BadRequest(result.Fail),
                HttpStatusCode.NotFound => Results.NotFound(result.Fail),
                _ => Results.BadRequest(result.Fail)
            };

        }
    }
}
