using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace Projeto_kanban.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
     
    }
}
