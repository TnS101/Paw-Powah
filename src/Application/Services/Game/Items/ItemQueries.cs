namespace Application.Services.Game.Items
{
    using Application.Common.Interfaces;
    using Application.Common.Query_Helpers;
    using Application.Common.Service_Helpers;
    using Application.Services.Game.Items.Models;
    using Application.Services.Interfaces.Game.Items;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Domain.Entities.Game.Units;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class ItemQueries : MapService<EquipableFullViewModel, ItemMinViewModel>, IItemQueries
    {
        public ItemQueries(IMapper mapper, IPawContext context)
            : base(mapper, context)
        {
        }

        public async Task<IEnumerable<IEnumerable<ItemMinViewModel>>> GetInventory(long playerId)
        {
            var amulets = await this.MapCollection(this.Context.PlayersAmulets.AsNoTracking().Where(p => p.PlayerId == playerId).Select(a => a.Amulet));
            var armor = await this.MapCollection(this.Context.PlayersArmors.AsNoTracking().Where(p => p.PlayerId == playerId).Select(a => a.Armor));
            var weapons = await this.MapCollection(this.Context.PlayersWeapons.AsNoTracking().Where(p => p.PlayerId == playerId).Select(w => w.Weapon));
            var consumeables = await this.MapCollection(this.Context.PlayersConsumeables.AsNoTracking().Where(p => p.PlayerId == playerId).Select(c => c.Consumeable));

            return new HashSet<IEnumerable<ItemMinViewModel>>
            {
                amulets, armor, weapons, consumeables
            };
        }

        public async Task<ConsumeableFullViewModel> GetConsumeable(int id)
        {
            return this.Mapper.Map<ConsumeableFullViewModel>(await this.Context.Consumeables.FindAsync(id));
        }

        public async Task<EquipableFullViewModel> GetEquipable(int id, string type)
        {
            return type switch
            {
                "Amulet" => this.MapInfo(await this.Context.Amulets.FindAsync(id)),
                "Armor" => this.MapInfo(await this.Context.Armors.FindAsync(id)),
                "Weapon" => this.MapInfo(await this.Context.Weapons.FindAsync(id)),
                _ => this.MapInfo(await this.Context.Consumeables.FindAsync(id)),
            };
        }

        public async Task<IEnumerable<EquipableFullViewModel>> GetEquipment(long playerId)
        {
            var armor = await this.Context.PlayersArmors.AsNoTracking().Where(p => p.PlayerId == playerId).Select(a => a.Armor).ProjectTo<EquipableFullViewModel>(this.Mapper.ConfigurationProvider).ToArrayAsync();

            return new HashSet<EquipableFullViewModel>(armor)
            {
                this.MapInfo(this.Context.PlayersAmulets.FirstOrDefault(p => p.PlayerId == playerId).Amulet),
                this.MapInfo(this.Context.PlayersWeapons.FirstOrDefault(p => p.PlayerId == playerId).Weapon)
            };
        }

        public async Task<IEnumerable<ItemMinViewModel>> GetAllItems(string type)
        {
            return type switch
            {
                "Amulet" => await this.MapCollection(this.Context.Amulets.AsNoTracking()),
                "Armor" => await this.MapCollection(this.Context.Armors.AsNoTracking()),
                "Weapon" => await this.MapCollection(this.Context.Weapons.AsNoTracking()),
                _ => await this.MapCollection(this.Context.Consumeables.AsNoTracking()),
            };
        }

        public async Task<IEnumerable<ItemMinViewModel>> GetSorted(string criteria, string condition, double value)
        {
            return await this.MapCollection(new QuerySorter<Player>().Execute(this.Context.Players.AsNoTracking(), criteria, condition, value));
        }
    }
}
