namespace Tetris.Model
{
    public class Game
    {
        private GameState _state;

        public GameState State
        {
            get { return _state; }
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
    }
}
