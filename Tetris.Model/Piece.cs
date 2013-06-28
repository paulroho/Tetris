namespace Tetris.Model
{
    public class Piece
    {
        private readonly Shape _shape;

        public Piece(Shape shape = default(Shape))
        {
            _shape = shape;
        }

        public Shape Shape
        {
            get { return _shape; }
        }
    }
}