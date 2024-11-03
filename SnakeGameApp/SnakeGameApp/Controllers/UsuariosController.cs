using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SnakeGameApp.Data;
using SnakeGameApp.Models;
using System.Threading.Tasks;

namespace SnakeGameApp.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly SnakeGameContext _context;

        public UsuariosController(SnakeGameContext context)
        {
            _context = context;
        }

        // Acción para mostrar el formulario de registro
        public IActionResult Crear()
        {
            return View();
        }

        // Acción para registrar un nuevo usuario
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                _context.Usuarios.Add(usuario);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Home");
            }
            return View(usuario);
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(string username, string contraseña)
        {
            if (ModelState.IsValid)
            {
                var usuario = await _context.Usuarios
                    .FirstOrDefaultAsync(u => u.Username == username);
                if (usuario != null && contraseña == usuario.ContraseñaHash)
                {
                    return RedirectToAction("Index", "Game");
                }
                ModelState.AddModelError("", "Nombre de usuario o contraseña incorrectos.");
            }
            return View();
        }

        public IActionResult Juego()
        {
            return View();
        }

        public IActionResult Registrar()
        {
            ViewBag.MensajeError = null;
            return View();
        }
    }
}
