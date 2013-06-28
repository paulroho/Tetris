namespace Tetris.Model
{
    public class Game
    {
        private readonly IPieceGenerator _pieceGenerator;
        private GameState _state;
        private Piece _currentPiece;

        public Game(IPieceGenerator pieceGenerator)
        {
            RowCount = 20;
            _state = GameState.Blank;
            _pieceGenerator = pieceGenerator;
        }

        public GameState State
        {
            get { return _state; }
        }

        public Piece CurrentPiece
        {
            get { return _currentPiece; }
        }

        public void Start()
        {
            _state = GameState.Running;
        }

        public void Pause()
        {
            _state = GameState.Pausing;
        }

        public void Resume()
        {
            _state = GameState.Running;
        }

        public void Tick()
        {
            _currentPiece = _pieceGenerator.GetNewPiece().AtRow(RowCount);
        }

        public int RowCount { get; set; }
    }
}
