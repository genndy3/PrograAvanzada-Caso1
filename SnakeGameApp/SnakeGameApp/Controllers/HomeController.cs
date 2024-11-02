using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SnakeGameApp.Data;
using System.Linq;
using System.Threading.Tasks;

namespace SnakeGameApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly SnakeGameContext _context;

        public HomeController(SnakeGameContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var partidas = _context.Partidas.ToList(); // Asegúrate de que esto retorne una lista
            return View(partidas);
        }

    }
}