namespace Paw_Powah.Controllers.api.Common
{
    using global::Common;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize(Roles = GConst.UserRole)]
    public class UserController : BaseController
    {
        public UserController()
        {
        }

        [HttpGet]
        public IActionResult Panel()
        {
            return this.View();
        }
    }
}
