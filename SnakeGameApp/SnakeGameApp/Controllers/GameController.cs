using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SnakeGameApp.Data;
using SnakeGameApp.Models;

namespace SnakeGameApp.Controllers
{
    public class GameController : Controller
    {

        private readonly SnakeGameContext _context;

        public GameController(SnakeGameContext context)
        {
            _context = context;
        }

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

        [HttpPost]
        public async Task<IActionResult> RegistrarPuntuacion([FromBody] Partida puntuacion)
        {
            // Accede a los datos recibidos
            string usuarioId = puntuacion.UsuarioID.ToString();
            int resultado = puntuacion.Resultado;


            Partida nuevaPartida = new Partida
            {
                UsuarioID = puntuacion.UsuarioID,
                Resultado = puntuacion.Resultado
            };

            if (ModelState.IsValid)
            {
                _context.Partidas.Add(nuevaPartida);
                await _context.SaveChangesAsync();
                return Json(new { UsuarioId = usuarioId, Resultado = resultado, Mensaje = "Puntuación registrada con éxito" });
            }

            // Retorna un resultado en formato JSON
            return Json(new { UsuarioId = usuarioId, Resultado = resultado, Mensaje = "Error" });
        }




    }
}