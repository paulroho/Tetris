using System.Drawing;

namespace Tetris.Model
{
    public class Piece
    {
        private readonly Shape _shape;
        private readonly Color _color;
        private readonly Orientation _orientation;

        public Piece(Shape shape = default(Shape), Color color = default (Color), Orientation orientation = default (Orientation))
        {
            _shape = shape;
            _color = color;
            _orientation = orientation;
        }

        public Shape Shape
        {
            get { return _shape; }
        }

        public Color Color
        {
            get { return _color; }
        }

        public Orientation Orientation
        {
            get { return _orientation; }
        }
    }
}