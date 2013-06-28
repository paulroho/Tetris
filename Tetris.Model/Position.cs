namespace Tetris.Model
{
    public struct Position
    {
        private readonly int _row;

        public Position(int row)
        {
            _row = row;
        }

        public int Row
        {
            get { return _row; }
        }
    }
}