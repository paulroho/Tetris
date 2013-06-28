using System.Drawing;

namespace Tetris.Model
{
    public class Piece
    {
        private readonly Shape _shape;
        private readonly Color _color;

        public Piece(Shape shape = default(Shape), Color color = default (Color))
        {
            _shape = shape;
            _color = color;
        }

        public Shape Shape
        {
            get { return _shape; }
        }

        public Color Color
        {
            get { return _color; }
        }

        public Position Position { get; set; }
    }
}