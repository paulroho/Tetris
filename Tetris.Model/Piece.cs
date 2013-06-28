using System.Drawing;

namespace Tetris.Model
{
    public class Piece
    {
        private readonly Shape _shape;
        private readonly Color _color;
        private readonly Position _position;

        public Piece(Shape shape = default(Shape), Color color = default (Color))
        {
            _shape = shape;
            _color = color;
        }

        private Piece(Piece originator, Position position)
        {
            _shape = originator.Shape;
            _color = originator.Color;
            _position = position;
        }

        public Shape Shape
        {
            get { return _shape; }
        }

        public Color Color
        {
            get { return _color; }
        }

        public Position Position
        {
            get { return _position; }
        }

        public Piece AtRow(int row)
        {
            var position = new Position(row);
            return new Piece(this, position);
        }
    }
}