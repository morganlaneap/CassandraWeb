using Microsoft.AspNetCore.Mvc;

namespace CassandraWeb.Controllers
{
    [Route("/")]
    public class AppController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
