namespace Application.Services.Game.Items
{
    using Application.Common.Interfaces;
    using Application.Common.Service_Helpers;
    using Application.Services.Interfaces.Game.Items;

    public class ItemCommands : BaseService, IItemCommands
    {
        public ItemCommands(IPawContext context)
            :base(context)
        {
        }
    }
}
