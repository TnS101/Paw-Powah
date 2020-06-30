namespace Paw_Powah.Controllers.api.Common
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;

    [AllowAnonymous]
    public class HomeController : BaseController
    {
        [HttpGet("/")]
        public IActionResult Index()
        {
            return this.View();
        }
    }
}
