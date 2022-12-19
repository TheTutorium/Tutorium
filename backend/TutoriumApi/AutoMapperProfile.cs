using AutoMapper;
using tutorium.Models;
using tutorium.Dtos.BookingDto;
using tutorium.Dtos.CourseDto;
using tutorium.Dtos.MaterialDto;
using tutorium.Dtos.ReviewDto;
using tutorium.Dtos.WhiteboardSaveDto;
using tutorium.Dtos.UserDto;

namespace tutorium
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Booking, BookingEndDto>()
                .ForMember(b => b.Duration, opt => opt.Ignore());

            CreateMap<Booking, GetBookingEndDto>()
                .ForMember(b => b.Duration, opt => opt.Ignore());

            CreateMap<Course, GetCourseDto>();

            CreateMap<Material, GetMaterialDto>();

            CreateMap<Review, GetReviewDto>();

            CreateMap<User, GetUserDto>();

            CreateMap<WhiteboardSave, GetWhiteboardSaveDto>();
        }
    }
}
