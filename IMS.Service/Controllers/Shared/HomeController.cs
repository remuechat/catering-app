namespace IMS.Service.Controllers
{
    // Controllers/HomeController.cs
    using Microsoft.AspNetCore.Mvc;

    namespace IMS.Service.Admin.Controllers
    {
        [ApiController]
        [Route("/")]
        public class HomeController : ControllerBase
        {
            [HttpGet]
            public IActionResult Get()
            {
                return Ok(new
                {
                    message = "IMS Service API",
                    version = "1.0",
                    documentation = "/swagger/index.html"
                });
            }
        }
    }

}
