namespace Paw_Powah.Controllers.api.Common
{
    using Microsoft.AspNetCore.Mvc;

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
