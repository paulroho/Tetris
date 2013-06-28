using FluentAssertions;
using Tetris.Model;

namespace Tetris.Specs.ShouldExtensions
{
    internal static class GameShouldExtensions
    {
        public static IGameShouldBeCondition ShouldBe(this Game game)
        {
            return new GameShouldBeCondition(game);
        }

        public static IGameShouldHaveCondition ShouldHave(this Game game)
        {
            return new GameShouldHaveCondition(game);
        }

        internal interface IGameShouldBeCondition
        {
            void Blank();
            void Running();
            void Pausing();
        }

        private class GameShouldBeCondition : IGameShouldBeCondition
        {
            private readonly Game _game;

            public GameShouldBeCondition(Game game)
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

        internal interface IGameShouldHaveCondition
        {
            void NoCurrentPiece();
            void ACurrentPiece();
            void CurrentPieceAtRow(int row);
            void NoObstacleUnderThePiece();
        }

        private class GameShouldHaveCondition : IGameShouldHaveCondition
        {
            private readonly Game _game;

            public GameShouldHaveCondition(Game game)
            {
                _game = game;
            }

            public void NoCurrentPiece()
            {
                _game.CurrentPiece.Should().BeNull();
            }

            public void ACurrentPiece()
            {
                _game.CurrentPiece.Should().NotBeNull();
            }

            public void CurrentPieceAtRow(int row)
            {
                _game.CurrentPiece.Position.Row.Should().Be(row);
            }

            public void NoObstacleUnderThePiece()
            {
                // Simplistic by now
                _game.CurrentPiece.Position.Row.Should().BeGreaterThan(1);
            }
        }
    }
}