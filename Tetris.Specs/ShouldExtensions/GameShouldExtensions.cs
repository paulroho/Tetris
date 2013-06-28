using FluentAssertions;
using Tetris.Model;

namespace Tetris.Specs.ShouldExtensions
{
    internal static class GameShouldExtensions
    {
        public static IGameShouldCondition ShouldBe(this Game game)
        {
            return new GameShouldCondition(game);
        }

        internal interface IGameShouldCondition
        {
            void Blank();
            void Running();
            void Pausing();
        }

        internal class GameShouldCondition : IGameShouldCondition
        {
            private readonly Game _game;

            public GameShouldCondition(Game game)
            {
                _game = game;
            }

            public void Blank()
            {
                _game.Should().NotBeNull();
                _game.State.Should().Be(GameState.Blank);
            }

            public void Running()
            {
                _game.State.Should().Be(GameState.Running);
            }

            public void Pausing()
            {
                _game.State.Should().Be(GameState.Pausing);
            }
        }
    }
}