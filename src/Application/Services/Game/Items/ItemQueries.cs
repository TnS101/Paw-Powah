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

        public async Task<IEnumerable<ItemMinViewModel>> GetInventory(long playerId)
        {
            var result = new HashSet<ItemMinViewModel>();

            await this.Context.PlayersAmulets.Where(p => p.PlayerId == playerId).Select(a => a.Amulet).ProjectTo<ItemMinViewModel>(this.Mapper.ConfigurationProvider).ForEachAsync(e => result.Add(e));
            await this.Context.PlayersArmors.Where(p => p.PlayerId == playerId).Select(a => a.Armor).ProjectTo<ItemMinViewModel>(this.Mapper.ConfigurationProvider).ForEachAsync(e => result.Add(e));
            await this.Context.PlayersWeapons.Where(p => p.PlayerId == playerId).Select(w => w.Weapon).ProjectTo<ItemMinViewModel>(this.Mapper.ConfigurationProvider).ForEachAsync(e => result.Add(e));
            await this.Context.PlayersConsumeables.Where(p => p.PlayerId == playerId).Select(c => c.Consumeable).ProjectTo<ItemMinViewModel>(this.Mapper.ConfigurationProvider).ForEachAsync(e => result.Add(e));

            return result;
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
            var result = new HashSet<EquipableFullViewModel>
            {
                this.MapInfo(this.Context.PlayersAmulets.FirstOrDefault(p => p.PlayerId == playerId).Amulet),
                this.MapInfo(this.Context.PlayersWeapons.FirstOrDefault(p => p.PlayerId == playerId).Weapon)
            };

            foreach (var armor in await this.Context.PlayersArmors.Where(p => p.PlayerId == playerId).Select(a => a.Armor).ProjectTo<EquipableFullViewModel>(this.Mapper.ConfigurationProvider).ToListAsync())
            {
                result.Add(armor);
            }

            return result;
        }

        public async Task<IEnumerable<ItemMinViewModel>> GetAllItems(string type)
        {
            return type switch
            {
                "Amulet" => await this.MapCollection(this.Context.Amulets),
                "Armor" => await this.MapCollection(this.Context.Armors),
                "Weapon" => await this.MapCollection(this.Context.Weapons),
                _ => await this.MapCollection(this.Context.Consumeables),
            };
        }

        public async Task<IEnumerable<ItemMinViewModel>> GetSorted(string criteria, string condition, double value)
        {
            return await this.MapCollection(new QuerySorter<Player>().Execute(this.Context.Players, criteria, condition, value));
        }
    }
}
