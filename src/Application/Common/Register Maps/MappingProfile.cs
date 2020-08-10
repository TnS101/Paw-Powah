namespace Application.Common.Register_Maps
{
    using Application.Services.Common.Users.ViewModels;
    using Application.Services.Game.Enemies.Models;
    using Application.Services.Game.GeneratedEnemies.Models;
    using Application.Services.Game.Items.Models;
    using Application.Services.Game.Players.Models;
    using Application.Services.Game.Spells.Models;
    using AutoMapper;
    using Domain.Entities.Game.Combat;
    using Domain.Entities.Game.Items;
    using Domain.Entities.Game.Units;
    using Domain.Identity;

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            this.CreateMap<AppUser, UserMinViewModel>();
            this.CreateMap<Enemy, EnemyMinViewModel>();
            this.CreateMap<Enemy, EnemyFullViewModel>();
            this.CreateMap<GeneratedEnemy, GeneratedEnemyViewModel>();

            this.CreateMap<Player, PlayerFullViewModel>().ForMember(p => p.KindName, opt => opt.Ignore()).ForMember(p => p.ClassName, opt => opt.Ignore());
            this.CreateMap<Player, PlayerBattleViewModel>().ForMember(p => p.KindName, opt => opt.Ignore()).ForMember(p => p.ClassName, opt => opt.Ignore());
            this.CreateMap<Player, PlayerMinViewModel>();

            this.CreateMap<Amulet, EquipableFullViewModel>().ForMember(i => i.SpecificProps, opt => opt.Ignore());
            this.CreateMap<Armor, EquipableFullViewModel>().ForMember(i => i.SpecificProps, opt => opt.Ignore());
            this.CreateMap<Weapon, EquipableFullViewModel>().ForMember(i => i.SpecificProps, opt => opt.Ignore());
            this.CreateMap<Consumeable, ConsumeableFullViewModel>();
            this.CreateMap<Spell, SpellFullViewModel>().ForMember(s => s.ClassName, opt => opt.Ignore()).ForMember(s => s.EnemyName, opt => opt.Ignore())
                .ForMember(s => s.KindName, opt => opt.Ignore());
            this.CreateMap<Spell, SpellMinViewModel>();


            this.CreateMap<Amulet, ItemMinViewModel>().ForMember(i => i.Count, opt => opt.Ignore());
            this.CreateMap<Armor, ItemMinViewModel>().ForMember(i => i.Count, opt => opt.Ignore());
            this.CreateMap<Weapon, ItemMinViewModel>().ForMember(i => i.Count, opt => opt.Ignore());
            this.CreateMap<Consumeable, ItemMinViewModel>().ForMember(i => i.Count, opt => opt.Ignore());
        }
    }
}
