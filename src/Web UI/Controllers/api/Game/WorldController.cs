namespace Paw_Powah.Controllers.api.Game
{
    using global::Common;
    using Microsoft.AspNetCore.Authorization;
    using Paw_Powah.Controllers.api.Common;

    [Authorize(Roles = GConst.UserRole)]
    public class WorldController : BaseController
    {
    }
}
