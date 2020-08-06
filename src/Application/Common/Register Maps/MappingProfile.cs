namespace Application.Common.Register_Maps
{
    using Application.Services.Common.Users.ViewModels;
    using Application.Services.Game.Enemies.Models;
    using AutoMapper;
    using Domain.Entities.Game.Units;
    using Domain.Identity;

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            this.CreateMap<AppUser, UserMinViewModel>();
            this.CreateMap<Enemy, EnemyMinViewModel>();
            this.CreateMap<GeneratedEnemy, GeneratedEnemyViewModel>();
        }
    }
}
