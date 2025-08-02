using CourseMicroservice.Catalog.Api.Features.Courses.Create;
using CourseMicroservice.Catalog.Api.Features.Courses.Dtos;

namespace CourseMicroservice.Catalog.Api.Features.Courses
{
    public class CourseMapping : Profile
    {
        public CourseMapping()
        {
            CreateMap<CreateCourseCommand, Course>();
            CreateMap<Course, CourseDto>()
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category));
        }
    }
}
