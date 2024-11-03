using System.Collections.Generic;
using System.Drawing;

namespace SnakeGameApp.Models
{
    public class Snake
    {
        public List<Point> Cuerpo { get; set; }
        public int Size { get; set; } = 50;

        public Snake()
        {
            Cuerpo = new List<Point>
            {
                new Point(100, 100),
                new Point(100, 150),
                new Point(100, 200)
            };
        }

        public void Grow()
        {
            if (Cuerpo.Count > 0)
            {
                Point tail = Cuerpo[Cuerpo.Count - 1];
                Cuerpo.Add(new Point(tail.X, tail.Y));
            }
        }
    }
}
