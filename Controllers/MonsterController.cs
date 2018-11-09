using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace Monsterpedia.Controllers
{
    public class MonsterController : Controller
    {
        // 
        // GET: /Monster/

        public IActionResult Index()
        {
            return View();
        }
    }
}