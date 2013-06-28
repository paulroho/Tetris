namespace Tetris.Model
{
    public interface IPieceGenerator
    {
        Piece GetNewPiece();
    }

    public class PieceGenerator : IPieceGenerator
    {
        public Piece GetNewPiece()
        {
            return new Piece();
        }
    }
}