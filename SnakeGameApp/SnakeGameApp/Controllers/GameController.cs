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
            var usuarioId = puntuacion.UsuarioID.ToString();
            int resultado = puntuacion.Resultado;

            // Verifica si el tiempo de juego se ha enviado correctamente
            TimeSpan tiempoDeJuego = puntuacion.TiempoDeJuego;  // Asume que se envía como TimeSpan en la solicitud

            Partida nuevaPartida = new Partida
            {
                UsuarioID = puntuacion.UsuarioID,
                Resultado = puntuacion.Resultado,
                TiempoDeJuego = tiempoDeJuego
            };

            if (ModelState.IsValid)
            {
                _context.Partidas.Add(nuevaPartida);
                await _context.SaveChangesAsync();
                return Json(new { UsuarioId = usuarioId, Resultado = resultado, TiempoDeJuego = tiempoDeJuego, Mensaje = "Puntuación registrada con éxito" });
            }

            // Retorna un resultado en formato JSON si hay un error
            return Json(new { UsuarioId = usuarioId, Resultado = resultado, Mensaje = "Error al registrar la puntuación" });
        }



    }
}