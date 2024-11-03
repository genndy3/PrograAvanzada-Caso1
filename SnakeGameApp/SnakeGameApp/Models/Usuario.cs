using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SnakeGameApp.Models
{
    public class Usuario
    {
        [Key]
        public int UsuarioID { get; set; }

        [Required(ErrorMessage = "El nombre de usuario es requerido.")]
        [StringLength(50, ErrorMessage = "El nombre de usuario no puede exceder los 50 caracteres.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "La contraseña es requerida.")]
        [StringLength(255, ErrorMessage = "La contraseña debe tener al menos 6 caracteres.", MinimumLength = 6)]
        public string ContraseñaHash { get; set; }

        public string FotoPerfil { get; set; }
    }
}