namespace Tetris.Model
{
    public class Game
    {
        private GameState _state;
        private Piece _currentPiece;

        public Game()
        {
            _state = GameState.Blank;
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
            _currentPiece = new Piece();
        }
    }
}
