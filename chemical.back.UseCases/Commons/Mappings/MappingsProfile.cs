using AutoMapper;
using chemical.back.Domain.Entities;
using chemical.back.DTO;

namespace chemical.back.UseCases.Commons.Mappings
{
    public class MappingsProfile : Profile
    {
        public MappingsProfile()
        {
            CreateMap<User, UserCreateDto>().ReverseMap()
                .ForMember(destination => destination.UseName, source => source.MapFrom(src => src.UserName))
                .ForMember(destination => destination.UsePassword, source => source.MapFrom(src => src.UserPassword))
                .ForMember(destination => destination.UseState, source => source.MapFrom(src => src.UserState));

            CreateMap<User, UserUpdateDto>().ReverseMap()
                .ForMember(destination => destination.UseId, source => source.MapFrom(src => src.UserId))
                .ForMember(destination => destination.UseName, source => source.MapFrom(src => src.UserName))
                .ForMember(destination => destination.UsePassword, source => source.MapFrom(src => src.UserPassword))
                .ForMember(destination => destination.UseState, source => source.MapFrom(src => src.UserState));

            CreateMap<User, UserRemoveDto>().ReverseMap()
                .ForMember(destination => destination.UseId, source => source.MapFrom(src => src.UserId))
                .ForMember(destination => destination.UseState, source => source.MapFrom(src => src.UserState));

            CreateMap<UserListarDto, User>().ReverseMap()
                .ForMember(destination => destination.UserId, source => source.MapFrom(src => src.UseId))
                .ForMember(destination => destination.UserName, source => source.MapFrom(src => src.UseName))
                .ForMember(destination => destination.UserState, source => source.MapFrom(src => src.UseState));
        }
    }
}
