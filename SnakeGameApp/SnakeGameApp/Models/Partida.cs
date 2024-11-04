using System.ComponentModel.DataAnnotations;

namespace SnakeGameApp.Models
{
    public class Partida
    {
        [Key]
        public int PartidaID { get; set; }

        public int UsuarioID { get; set; }
        public Usuario? Usuario { get; set; }

        public int Resultado { get; set; }
        public TimeSpan TiempoDeJuego { get; set; }
    }
}