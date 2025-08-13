
namespace CourseMicroservice.Shared.Services
{
    public class IdentityService : IIdentityService
    {
        public Guid GetUserId => Guid.Parse("08ddd1c1-84d9-d38c-0009-0faa00010000");

        public string GetUserName => "Palaz123";
    }
}
