using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SnakeGameApp.Data;
using SnakeGameApp.Models;

namespace SnakeGameApp.Controllers
{
    public class GameController : Controller
    {
        public ActionResult Index()
        {

            Snake snake = new Snake();
            Apple manzana = new Apple();

            var model = new VistaJuego
            {
                Snake = snake,
                Apple = manzana,
            };

            return View(model);

        }
    }
}
