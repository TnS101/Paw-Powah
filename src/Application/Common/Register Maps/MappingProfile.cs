namespace Application.Common.Register_Maps
{
    using Application.Services.Common.Users.ViewModels;
    using AutoMapper;
    using Domain.Identity;

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            this.CreateMap<AppUser, UserMinViewModel>();
        }
    }
}
