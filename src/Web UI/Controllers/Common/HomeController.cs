namespace Paw_Powah.Controllers.Common
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;

    [AllowAnonymous]
    public class HomeController : BaseController
    {
        public IActionResult Index()
        {
            return this.View();
        }
    }
}
